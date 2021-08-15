using System;
using Management.Models;
using Management.Data;

namespace Management.BusinessLogic
{
    public class CustomerActions: IBusinessLogicCustomer
    {
        //set customer actions to read data from file
        private readonly ICustomerDataStore _dataStore;
        public CustomerActions(ICustomerDataStore dataStore)
        {
            _dataStore = dataStore;
            _dataStore.ReadCustomersDataFromFile();
        }

        //register customer method
        //create user object and add it to list<customer>
        public Customer RegisterCustomer(string firstName, string lastName, string email, string password)
        {
            Customer newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _dataStore.customers.Add(newCustomer);
            return newCustomer;
        }   

        //login method
        //check if email and password match
        //return values are used to control UI
        public int LoginCustomer(string firstName, string lastName, string email, string password)
        {
            _dataStore.ReadCustomersDataFromFile();
            var dataList = _dataStore.customers;
            foreach (var customer in dataList)
            {
                if (customer.Email == email && customer.Password == password)
                {
                    return 1;
                } 
                else
                {
                    return -1; 
                }          
            }
            return -1;
        }

        //save customer to file
        public void SaveCustomerChanges()
        {
            _dataStore.WriteCustomersDataToFile();
        }

    }
}
