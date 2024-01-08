using DQFunnel.ElasticDataAccess.Interfaces;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DQFunnel.ElasticDataAccess
{
    public class ElasticRepository<T> : IElasticRepository<T> where T : class
    {
        /// <summary>
        /// URI 
        /// </summary>
        private const string ES_URI = "https://localhost:9200";

        /// <summary>
        /// Elastic settings
        /// </summary>
        private ConnectionSettings _settings;

        /// <summary>
        /// Current instantiated client
        /// </summary>
        public ElasticClient Current { get; set; }
        private string _indexName;
        public ElasticRepository(string indexName)
        {
            ElasticConfig(indexName, ES_URI);
        }

        public ElasticRepository(string indexName, string elasticHost)
        {
            ElasticConfig(indexName, elasticHost);
        }

        private void ElasticConfig(string indexName, string elasticHost)
        {
            var node = new Uri(elasticHost);
            _settings = new ConnectionSettings(node);
            _indexName = indexName;
            _settings.DefaultMappingFor<T>(i => i
                    .IndexName(indexName)
                 )
                .EnableDebugMode()
                .PrettyJson()
                .RequestTimeout(TimeSpan.FromMinutes(2));
            Current = new ElasticClient(_settings);
        }

        public bool Index(T entity)
        {
            var indexResponse = Current.IndexDocument(entity);
            if (!indexResponse.IsValid)
                throw new Exception(indexResponse.ServerError.Error.ToString());
            else
                return true;
        }

        public T QueryById(string id)
        {
            QueryContainer queryById = new TermQuery() { Field = "_id", Value = id.Trim() };

            var hits = Current
                            .Search<T>(s => s.Query(q => q.MatchAll() && queryById))
                                   .Hits;

            T objectResult = hits.Select(hit => ConvertHitToObject(hit)).FirstOrDefault();

            return objectResult;
        }

        private T ConvertHitToObject(IHit<T> hit)
        {
            Func<IHit<T>, T> func = (x) =>
            {
                return hit.Source;
            };

            return func.Invoke(hit);
        }


        public List<T> QueryAll()
        {
            var hits = Current
                            .Search<T>(s => s
                            .From(0)
                            .Size(10000)
                            .Query(q => q.MatchAll())
                            .Scroll("5m"))
                                   .Hits;

            List<T> listResult = hits.Select(hit => ConvertHitToObject(hit)).ToList();

            return listResult;
        }
    }
}