using System;
using System.Collections.Generic;
using Management.Models;
using Management.Data;

namespace Management.BusinessLogic
{
    public class StoreActions: IBusinessLogicStore
    {
        // list to store products
        public List<int> productsList = new List<int>();

        //actions to collect data from store
        private readonly IStoreDataStore _dataStore;
        public StoreActions(IStoreDataStore dataStore)
        {
            _dataStore = dataStore;
            _dataStore.ReadStoreDataFromFile();
        }

        //create store method
        public Store CreateStore(string storeName, string storeNumber, string storeType, int products)
        {
            Store newStore = new Store
            {
                StoreName = storeName,
                StoreNumber = storeNumber,
                StoreType = storeType,
                Products = products
            };
            _dataStore.stores.Add(newStore);
            return newStore;
        }

        //save changes to store
        public void SaveStoreChanges()
        {
            _dataStore.WriteStoreDataToFile();
        }

        //add product method
        public int AddProduct(int products)
        {
            productsList.Add(products);
            return products;
        }

        //remove product method
        public void RemoveProduct(int product)
        {
            productsList.Remove(product);
        }

        //display stores
        public List<Store> DisplayStores()
        {
            return _dataStore.stores;
        }
    }
}
