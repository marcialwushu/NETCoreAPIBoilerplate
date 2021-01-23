using System.Collections.Generic;
using JDPI.Application.API.Models;
using JDPI.Platform.Util.Providers;
using MongoDB.Driver;

namespace JDPI.Application.API.Services
{
    public class UserService
    {
        private readonly IMongoCollection<Usuario> _user;

        public UserService(ConfigProvider settings)
        {
            var client = new MongoClient(settings.DbUrl);
            var database = client.GetDatabase(settings.DbName);

            _user = database.GetCollection<Usuario>(settings.DbUsername);
        }

        public List<Usuario> listar()=> 
            _user.Find(user => true).ToList();
    }
}