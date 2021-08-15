using System;
using Management.Commons;

namespace Management.Models
{
    //the customer class will hold information about the customer such as names and email
    public class Customer
    {
        //use encapsulation to set the details of the customer
        private string firstName;
        public string FirstName
        {
            get {return firstName; }
            //set the first name to equal the value of first name that is formatted
            set { firstName = CustomerValidation.FormatName(value); }
        }

        private string lastName;
        public string LastName
        {
            get {return lastName; }
            set { lastName = CustomerValidation.FormatName(value); }
        }

        private string email;
        public string Email 
        {
            get{return email;}
            set{email = CustomerValidation.ValidateEmail(value);}
        }

        private string password;
        public string Password 
        {
            get{return password;}
            set{password = CustomerValidation.ValidatePassword(value);}
        }
    }
}
