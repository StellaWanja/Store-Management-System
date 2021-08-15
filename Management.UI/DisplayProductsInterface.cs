using System;
using Management.Models;
using Management.Commons;
using Management.BusinessLogic;

namespace Management.UI
{
    public class DisplayProductsInterface
    {
        private static int products;

        public static void DisplayProducts(IBusinessLogicStore actionsStore)
        {
            Console.WriteLine("Choose one of the options below:");
            Console.WriteLine("1 to Add products to store");
            Console.WriteLine("2 to Remove products");
            Console.WriteLine("4 to Get the store details and products"); 

            var consoleInput = InputValidation.storeInputValidity(Console.ReadLine());
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
                                System.Console.WriteLine("ENTER store products");
                                var productsInput = StoreValidation.IsValidInput(Console.ReadLine());
                                if(productsInput == -1)
                                {
                                    System.Console.WriteLine("Kindly enter numbers");
                                    productsInput = StoreValidation.IsValidInput(Console.ReadLine());
                                }
                                products = StoreValidation.ValidateProducts(productsInput);

                                actionsStore.AddProduct(products);
                                actionsStore.SaveStoreChanges();
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
                                System.Console.WriteLine("ENTER product to be removed");
                                var productsInput = StoreValidation.IsValidInput(Console.ReadLine());
                                if(productsInput == -1)
                                {
                                    System.Console.WriteLine("Kindly enter numbers");
                                    productsInput = StoreValidation.IsValidInput(Console.ReadLine());
                                }
                                products = StoreValidation.ValidateProducts(productsInput);
                                actionsStore.RemoveProduct(products);
                                actionsStore.SaveStoreChanges();
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
                        case 4:
                            try
                            {
                                System.Console.WriteLine("Store Details: ");
                                var stores =  actionsStore.DisplayStores();
                                DataDisplayInTable.DisplayDataTable(stores);
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
                        default:
                            break;
                    }
            }
        }        
    }
}