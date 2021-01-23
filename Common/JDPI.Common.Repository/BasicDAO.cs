using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System;
using JDPI.Common.Domain;
using JDPI.Common.Repository.Interfaces;
using JDPI.Common.Util;

namespace JDPI.Common.Repository
{
    public class BasicDAO<TCollection> : IBasicDAO<TCollection> where TCollection : IEntity
    {
        protected string _dbName { get; private set; } = string.Empty;

		protected string _dbUrl { get; private set; } = string.Empty;

		protected IMongoDatabase Db;
        
		private IMongoClient _client;
    }
}