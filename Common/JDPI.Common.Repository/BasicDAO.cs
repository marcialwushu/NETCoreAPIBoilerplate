using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System;
using JDPI.Common.Domain;
using JDPI.Common.Repository.Interfaces;
using JDPI.Common.Util;
using System.Linq;

namespace JDPI.Common.Repository
{
    public class BasicDAO<TCollection> : IBasicDAO<TCollection> where TCollection : IEntity
    {
        protected string _dbName { get; private set; } = string.Empty;

		protected string _dbUrl { get; private set; } = string.Empty;

		protected IMongoDatabase Db => Client.GetDatabase(_dbName);

        protected IMongoCollection<TCollection> Collection;
        
		private IMongoClient _client;

        public IMongoClient Client
        {
            get
            {
                if(_client == null)
                {
                    _client = new MongoClient(_dbUrl);
                }
                return _client;
            }
        }

        public BasicDAO() { }
        
        public BasicDAO(string collection, IConfigProvider configHelper)
        {
            this._dbName = configHelper.DbName;
            this._dbUrl = configHelper.DbUrl;
            Collection = Db.GetCollection<TCollection>(collection);
        }

        public void GetCollection(string collectionName)
        {
            Collection = Db.GetCollection<TCollection>(collectionName);
        }

        public virtual TCollection GetById(string id)
        {
            return Collection.Find(FilterById(id)).FirstOrDefault();
        }

        public virtual List<TCollection> GetListById(string id)
		{
			return Collection.Find(FilterById(id)).ToList();
		}

        protected FilterDefinition<TCollection> FilterById(string id)
		{
			return Builders<TCollection>.Filter.Eq("_id", BsonObjectId.Create(id));
		}

        public virtual IQueryable<TCollection> Get()
        {
            return Collection.AsQueryable();
        }

        public virtual void SaveAll(IList<TCollection> models) 
        {
            Collection.InsertMany(models);
        }

        public virtual void Save(TCollection model) 
        {
            Collection.InsertOne(model);
        }

        public virtual void Update(TCollection model) 
        {
           var filter = Builders<BsonDocument>.Filter.Eq("_id", model);
           var update = Builders<BsonDocument>.Update.Set("_id", model);
           Collection.UpdateOne(filter, update);
        }
    }
}