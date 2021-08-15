using System.Collections.Generic;
using Management.Models;

namespace Management.Data
{
    public interface ICustomerDataStore
    {
        List<Customer> customers { get; set; }

        void ReadCustomersDataFromFile();
        void WriteCustomersDataToFile();
    }
}