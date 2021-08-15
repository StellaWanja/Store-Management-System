using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Management.Models;

namespace Management.Data
{
    public class CustomerDataStore : ICustomerDataStore
    {
        public List<Customer> customers { get; set; } = new List<Customer>();

        public async void WriteCustomersDataToFile()
        {
            string filePath = @"../RegisterationDetails.txt";
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using FileStream fs = File.Create(filePath);
            fs.Dispose();

            var openedFile = File.AppendText(filePath);
            foreach (var customer in customers)
            {
                await openedFile.WriteLineAsync($"{customer.FirstName},{customer.LastName},{customer.Email},{customer.Password}");
            }
            openedFile.Dispose();
        }

        public void ReadCustomersDataFromFile()
        {
            string filePath = @"../RegisterationDetails.txt";
            if (!File.Exists(filePath))
            {
                using FileStream fs = File.Create(filePath);
                return;
            }
            var openedFile = File.ReadAllLines(filePath);

            foreach (var userDetail in openedFile)
            {
                var data = userDetail.Split(',');
                Customer customer = new Customer
                {
                    FirstName = data[0],
                    LastName = data[1],
                    Email = data[2],
                    Password = data[3]
                };

                customers.Add(customer);
            }
            return;
        }
    }
}