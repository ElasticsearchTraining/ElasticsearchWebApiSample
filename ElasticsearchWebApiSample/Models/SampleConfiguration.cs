using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticsearchWebApiSample.Models
{
    public class SampleConfiguration
    {
        public SampleConfiguration()
        {
            //System.Configuration.Configuration SampleWebConfig =
            //            System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
            //System.Configuration.KeyValueConfigurationElement ElasticsearchServer =
            //    SampleWebConfig.AppSettings.Settings["ElasticsearchServer"];
            //if (ElasticsearchServer != null)
            //        ElasticsearchServerHost = ElasticsearchServer.Value;
            ElasticsearchServerHost = System.Configuration.ConfigurationManager.AppSettings["ElasticsearchServer"];

        }

        public string ElasticsearchServerHost { get; set; }
    }
}