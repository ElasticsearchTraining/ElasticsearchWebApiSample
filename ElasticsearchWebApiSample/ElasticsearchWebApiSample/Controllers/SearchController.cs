using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using ElasticsearchWebApiSample.Models;
using Nest;

namespace ElasticsearchWebApiSample.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        public Uri esNode;
        public ConnectionSettings connectionSettings;
        public ElasticClient esClient;

        [AcceptVerbs("POST")]
        [Route("index")]
        public HttpResponseMessage CreateIndex(FormDataCollection postData)
        {
            SampleConfiguration config = new SampleConfiguration();
            esNode = new Uri(config.ElasticsearchServerHost);
            string indexName = postData.Get("indexName");
            connectionSettings = new ConnectionSettings(esNode, defaultIndex: indexName);

            var indexSettings = new IndexSettings();
            indexSettings.NumberOfShards = 1;
            indexSettings.NumberOfReplicas = 0;
            esClient = new ElasticClient(connectionSettings);

            IIndicesOperationResponse indexOperationResponse = esClient.CreateIndex(c => c
                .Index(indexName)
                .InitializeUsing(indexSettings)
                .AddMapping<Product>(m => m.MapFromAttributes())
                );

            if (indexOperationResponse.Acknowledged == true)
                return Request.CreateResponse(HttpStatusCode.Created, indexOperationResponse.Acknowledged);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError, indexOperationResponse.Acknowledged);
        }

        [AcceptVerbs("POST")]
        [Route("product")]
        public HttpResponseMessage CreateDocument(FormDataCollection postData)
        {
            SampleConfiguration config = new SampleConfiguration();
            esNode = new Uri(config.ElasticsearchServerHost);
            connectionSettings = new ConnectionSettings(esNode, defaultIndex: postData.Get("indexName"));
            esClient = new ElasticClient(connectionSettings);

            var product = new Product(Convert.ToInt32(postData.Get("id")),
                postData.Get("name"),
                postData.Get("brand"),
                Convert.ToDouble(postData.Get("price")));

            IIndexResponse indexResponse = esClient.Index(product);

            return Request.CreateResponse(HttpStatusCode.Created, indexResponse.Created);
        }

        [AcceptVerbs("GET")]
        [Route("")]
        public IHttpActionResult PerformSearch([FromUri] string indexName, 
            [FromUri] string searchTerm)
        {
            SampleConfiguration config = new SampleConfiguration();
            esNode = new Uri(config.ElasticsearchServerHost);
            connectionSettings = new ConnectionSettings(esNode, defaultIndex: indexName);
            esClient = new ElasticClient(connectionSettings);

            var esResults = esClient.Search<Product>(s => s
                .Query(p => p.MatchPhrase(m => m.OnField("name").Query(searchTerm)))
                //.Filter(f => f.Range(r => r.OnField("price").GreaterOrEquals(10).LowerOrEquals(20)))
                );

            return Ok(esResults.Documents);
            
        }

    }
}
