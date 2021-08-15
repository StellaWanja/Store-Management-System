using System.Collections.Generic;
using Management.Models;

namespace Management.Data
{
    public interface IStoreDataStore
    {
        List<Store> stores { get; set; }

        void ReadStoreDataFromFile();
        void WriteStoreDataToFile();
    }
}