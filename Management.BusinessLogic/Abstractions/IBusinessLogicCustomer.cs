using System;
using Management.Models;

namespace  Management.BusinessLogic
{
    public interface IBusinessLogicCustomer
    {
        Customer RegisterCustomer(string firstName, string lastName, string email, string password);
        
        void SaveCustomerChanges();
        int LoginCustomer(string firstName, string lastName, string email, string password);
        // Customer Logout();
    }
}