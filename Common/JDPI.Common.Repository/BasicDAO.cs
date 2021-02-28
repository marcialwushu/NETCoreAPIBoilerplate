using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System;
using JDPI.Common.Domain;
using JDPI.Common.Repository.Interfaces;
using JDPI.Common.Util;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using JDPI.Common.Util.Providers;
using JDPI.Platform.Entity;

namespace JDPI.Common.Repository
{
    public class BasicDAO<TCollection> : IBasicDAO<TCollection> where TCollection : IEntity
    {
        public BasicDAO(string _dbName, string _dbUrl)
        {
            this._dbName = _dbName;
            this._dbUrl = _dbUrl;

        }
        
        protected string _dbName { get; private set; } = string.Empty;

        protected string _dbUrl { get; private set; } = string.Empty;

        protected IMongoDatabase Db => Client.GetDatabase(_dbName);

        protected IMongoCollection<TCollection> Collection;

        private IMongoClient _client;
        private object _context;

        public IMongoClient Client
        {
            get
            {
                if (_client == null)
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
            Collection.ReplaceOne(FilterById(Convert.ToString(BsonTypeMapper.MapToDotNetValue(model.ToBsonDocument().GetElement("_id").Value))), model);
        }

        public virtual void Remove(string id)
		{
			Collection.DeleteOne(FilterById(id));
		}

		public virtual List<TCollection> GetAll()
		{
			List<TCollection> list = Collection.Find(_ => true).ToList();
			return list;
		}

		public virtual TCollection GetByPropertyName(string param, string property)
		{
			return Collection.Find(FilterByProperty(param, property)).FirstOrDefault();
		}

		public virtual List<TCollection> GetListByPropertyName(string param, string property)
		{
			List<TCollection> list = Collection.Find(FilterByProperty(param, property)).ToList();
			return list;
		}

        public virtual List<TCollection> GetListByParams(string param, string property)
        {
            return Collection.Find(FilterByProperty(param, property)).ToList();
        }

        /// <summary>
        /// (Filter & Linq) 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public virtual User FindElementInCollection(string userName)
        {
            var elementFilter = Builders<User>.Filter
                .ElemMatch(z => z.Users, a => a.UserName == userName);

            var element = Db.GetCollection<User>("User")
                .Find(elementFilter)
                .FirstOrDefault();
            return element.Users.FirstOrDefault(a => a.UserName == userName);
        }

        /// <summary>
        /// (Aggregation)
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public virtual User FindElementInCollection2(string userName)
        {
            var elementFilter = Builders<User>.Filter
                .ElemMatch(z => z.Users, a => a.UserName == userName);

            return Db.GetCollection<User>("user").Aggregate()
                .Match(elementFilter)
                .Project<User>(
                    Builders<User>.Projection.Expression<User>(z =>
                        z.Users.FirstOrDefault(a => a.UserName == userName)))
                .FirstOrDefault();
        }

        protected FilterDefinition<TCollection> FilterByProperty(string param, string property)
		{
			ParameterExpression expressionParameter = Expression.Parameter(typeof(TCollection), "t");

			Expression searchProperty = Expression.Property(expressionParameter, property);

			var seekenValue = Expression.Constant(param);

			Expression expression = Expression.Equal(searchProperty, seekenValue);

			return Expression.Lambda<Func<TCollection, bool>>(expression, expressionParameter);
		}

        
    }
}