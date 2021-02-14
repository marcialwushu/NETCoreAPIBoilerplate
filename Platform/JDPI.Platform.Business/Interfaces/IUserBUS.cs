using JDPI.Common.Business;
using JDPI.Common.Domain;

namespace JDPI.Platform.Business.Interfaces
{
    public interface IUserBUS<TCollection> : IBasicBUS<TCollection> where TCollection : IEntity
    {
         
    }
}