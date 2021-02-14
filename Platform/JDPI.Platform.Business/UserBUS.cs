using System.Collections.Generic;
using JDPI.Platform.Business.Interfaces;
using JDPI.Platform.Entity;
using JDPI.Platform.Repository.Interfaces;

namespace JDPI.Platform.Business
{
    public class UserBUS : IUserBUS<User>
    {
        IUserDAO<User> _userDAO;

        public UserBUS()
        {
            
        }

        public UserBUS(IUserDAO<User> userDAO)
        {
            this._userDAO = userDAO;
        }
        
        public List<User> GetAll()
        {
            //return _userDAO.GetAll();
            throw new System.NotImplementedException();
        }

        public User GetById(string id)
        {
            //return _userDAO.GetById(id);
            throw new System.NotImplementedException();
        }

        public User GetByPropertyName(string param, string property)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<User> GetListById(string id)
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.List<User> GetListByPropertyName(string param, string property)
        {
            throw new System.NotImplementedException();
        }

        public void Save(User model)
        {
            throw new System.NotImplementedException();
        }

        public void Update(User model)
        {
            throw new System.NotImplementedException();
        }
    }
}