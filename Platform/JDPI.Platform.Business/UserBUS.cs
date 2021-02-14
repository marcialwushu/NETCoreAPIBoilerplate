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
            return _userDAO.GetAll();            
        }

        public User GetById(string id)
        {
            return _userDAO.GetById(id);
        }

        public User GetByPropertyName(string param, string property)
        {
            return _userDAO.GetByPropertyName(param, property);
        }

        public System.Collections.Generic.List<User> GetListById(string id)
        {
            return _userDAO.GetListById(id);
        }

        public System.Collections.Generic.List<User> GetListByPropertyName(string param, string property)
        {
            return _userDAO.GetListByPropertyName(param, property);
        }

        public void Save(User model)
        {
             _userDAO.Save(model);
        }

        public void Update(User model)
        {
            _userDAO.Update(model);
        }
    }
}