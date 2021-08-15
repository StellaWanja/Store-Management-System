using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Management.Models;

namespace Management.Data
{
    public class StoreDataStore : IStoreDataStore
    {
        public List<Store> stores { get; set; } = new List<Store>();
        
        public async void WriteStoreDataToFile()
        {
            string filePath = @"../StoreDetails.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using FileStream fs = File.Create(filePath);
            fs.Dispose();

            var openedFile = File.AppendText(filePath);
            foreach (var store in stores)
            {
                await openedFile.WriteLineAsync($"{store.StoreName},{store.StoreNumber},{store.StoreType},{store.Products}");
            }
            openedFile.Dispose();
        }

        public void ReadStoreDataFromFile()
        {
            string filePath = @"../StoreDetails.txt";
            if (!File.Exists(filePath))
            {
                using FileStream fs = File.Create(filePath);
                return;
            }
            var openedFile = File.ReadAllLines(filePath);

            foreach (var userDetail in openedFile)
            {
                var data = userDetail.Split(',');
                Store store = new Store
                {
                    StoreName = data[0],
                    StoreNumber = data[1],
                    StoreType = data[2],
                    Products = Int32.Parse(data[3])
                };

                stores.Add(store);
            }
            return;
        }
    }
}