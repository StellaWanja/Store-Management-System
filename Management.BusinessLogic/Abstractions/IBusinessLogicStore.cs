using System;
using System.Collections.Generic;
using Management.Models;

namespace  Management.BusinessLogic
{
    public interface IBusinessLogicStore
    {
        Store CreateStore(string storeName, string storeNumber, string storeType, int products);
        
        void SaveStoreChanges();
        List<Store> DisplayStores();

        int AddProduct(int products);
        void RemoveProduct(int product);
    }
}