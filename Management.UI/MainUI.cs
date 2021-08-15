using System;
using System.Threading.Tasks;
using Management.Models;
using Management.Commons;
using Management.BusinessLogic;

namespace Management.UI
{
    public class MainUI
    {
        private static string firstName;
        private static string lastName;
        private static string emailAddress;
        private static string userPassword;

        public async Task DisplayDashboard(IBusinessLogicCustomer actionsCustomer, IBusinessLogicStore actionsStore)
        {
            bool appShouldRun = true;
            while (appShouldRun)
            {
                Console.WriteLine("Welcome to my store management app.");
                Console.WriteLine("Enter: ");
                Console.WriteLine("1 to Register");
                Console.WriteLine("2 to Login");
                Console.WriteLine("0 to exit");

                var consoleInput = InputValidation.accountInputValidity(Console.ReadLine());
                if (consoleInput == -1)
                {
                    Console.WriteLine("Please enter a valid input");
                    Console.Clear();
                }
                else
                {
                    switch (consoleInput)
                    {
                        case 1:
                            try
                            {
                                System.Console.WriteLine("Enter your first name");
                                string firstNameInput = Console.ReadLine();
                                firstName = CustomerValidation.FormatName(firstNameInput);

                                System.Console.WriteLine("Enter your last name");
                                string lastNameInput = Console.ReadLine();
                                lastName = CustomerValidation.FormatName(lastNameInput);

                                System.Console.WriteLine("Enter your email");
                                string emailAddressInput = Console.ReadLine();
                                emailAddress = CustomerValidation.ValidateEmail(emailAddressInput);

                                System.Console.WriteLine("Enter your password");
                                string userPasswordInput = Console.ReadLine();
                                userPassword = CustomerValidation.ValidatePassword(userPasswordInput);

                                Customer customer = actionsCustomer.RegisterCustomer(firstName, lastName, emailAddress, userPassword);
                                actionsCustomer.SaveCustomerChanges();
                                System.Console.WriteLine($"{firstName} {lastName} has been registered");

                                DisplayStoreInterface.DisplayStore(actionsStore);
                                Console.WriteLine();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (FormatException ex) 
                            //Catch all errors relating to argument formats operations
                            {

                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (Exception e)  
                            //Catch all unforseen errors
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            try
                            {
                                System.Console.WriteLine("Enter your first name");
                                string firstNameInput = Console.ReadLine();
                                firstName = CustomerValidation.FormatName(firstNameInput);

                                System.Console.WriteLine("Enter your last name");
                                string lastNameInput = Console.ReadLine();
                                lastName = CustomerValidation.FormatName(lastNameInput);

                                System.Console.WriteLine("Enter your email");
                                string emailAddressInput = Console.ReadLine();
                                emailAddress = CustomerValidation.ValidateEmail(emailAddressInput);

                                System.Console.WriteLine("Enter your password");
                                string userPasswordInput = Console.ReadLine();
                                userPassword = CustomerValidation.ValidatePassword(userPasswordInput);

                                var login = actionsCustomer.LoginCustomer(firstName, lastName, emailAddress, userPassword);

                                if (login == 1)
                                {                                
                                    System.Console.WriteLine("Login successful");
                                    DisplayStoreInterface.DisplayStore(actionsStore);
                                }
                                else
                                {
                                    System.Console.WriteLine("Email or password do not match");
                                }
                                Console.WriteLine();
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (FormatException ex) 
                            //Catch all errors relating to argument formats operations
                            {

                                Console.WriteLine(ex.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            catch (Exception e)  
                            //Catch all unforseen errors
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 0:
                            try
                            {
                                appShouldRun = false;
                            }
                            catch (Exception e)  //Catches all unforseen errors
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}




