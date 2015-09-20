[![Build status](https://ci.appveyor.com/api/projects/status/uk5978udclo9e9d0?svg=true)](https://ci.appveyor.com/project/rajanm/elasticsearchwebapisample)

ElasticsearchWebApiSample
=========================

This is a sample Web Api project project using the NEST library. This project has been written using Visual Studio Express 2015 for Web. This project has been tested with ElasticSearch Server v1.7.1.

Project Details:
----------------
- Microsoft .Net Framework v4.5
- Microsoft Web Api
- NEST

Prerequisites:
--------------
- Git Bash / Client
- Microsoft .Net Framework v4.5
- Visual Studio Express 2015 for Web
- Elasticsearch v1.7.1
- cURL or Postman or similar browser extension

Build Steps: 
------------
- Clone this repository.
- Open the solution in Visual Studio Express 2015 for Web or higher edition. Run the project.
- Set the Elasticsearch server URL in web.config.

Tips:
-----
- Run ElasticSearch Server locally. Set up the cluster.name in elasticsearch.yml as "elasticsearch-local".
- Refer the [Elasticsearch Samples Gist](https://gist.github.com/rajanm/3fdbc7999f0120ce5e87) for scripts
to create indices and documents.
- Install and use the Head plugin in ElasticSearch to view the indices, documents, queries, cluster and node status etc.
