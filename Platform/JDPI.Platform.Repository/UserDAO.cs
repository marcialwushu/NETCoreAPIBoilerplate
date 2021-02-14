using JDPI.Common.Repository;
using JDPI.Common.Util.Providers;
using JDPI.Platform.Entity;
using JDPI.Platform.Repository.Interfaces;

namespace JDPI.Platform.Repository
{
    public class UserDAO<TCollection> : BasicDAO<User> , IUserDAO<User>
    {
        const string _collectionName = "User";

        protected IConfigProvider _configHelper;

        public UserDAO(IConfigProvider configHelper) : base(_collectionName, configHelper)
        {
            _configHelper = configHelper;
        }
    }
}