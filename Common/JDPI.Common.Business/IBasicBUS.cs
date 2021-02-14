using JDPI.Common.Domain;
using System.Collections;
using System.Collections.Generic;

namespace JDPI.Common.Business
{
    public interface IBasicBUS<TCollection> where TCollection : IEntity
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