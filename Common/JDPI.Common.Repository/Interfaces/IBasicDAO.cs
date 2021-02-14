using System.Collections.Generic;
using JDPI.Common.Domain;

namespace JDPI.Common.Repository.Interfaces
{
    public interface IBasicDAO<TCollection> where TCollection : IEntity
    {
        void Save(TCollection model);
		TCollection GetById(string id);
		List<TCollection> GetAll();
		List<TCollection> GetListById(string id);
		List<TCollection> GetListByPropertyName(string param, string property);
		TCollection GetByPropertyName(string param, string property);
		void Update(TCollection model);
    }
}