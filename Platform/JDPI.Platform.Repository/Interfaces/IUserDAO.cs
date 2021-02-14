using JDPI.Common.Domain;
using JDPI.Common.Repository.Interfaces;

namespace JDPI.Platform.Repository.Interfaces
{
    public interface IUserDAO<TCollection> : IBasicDAO<TCollection> where TCollection : IEntity
    {
         
    }
}