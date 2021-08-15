using System;
using Management.Models;
using Management.Commons;
using Management.BusinessLogic;

namespace Management.UI
{
    public class DisplayStoreInterface
    {
        private static string storeName;
        private static string storeNumber;
        private static string storeType;
        private static int products; 

        public static void DisplayStore(IBusinessLogicStore actionsStore)
        {
            try
            {
                System.Console.WriteLine("Create your store");

                System.Console.WriteLine("ENTER store name");
                string storeNameInput = Console.ReadLine();
                storeName = StoreValidation.FormatName(storeNameInput);

                System.Console.WriteLine("ENTER store number");
                string storeNumberInput = Console.ReadLine();
                storeNumber = StoreValidation.FormatStoreNumber(storeNumberInput);

                System.Console.WriteLine("ENTER store type");
                string storeTypeInput = Console.ReadLine();
                storeType = StoreValidation.FormatName(storeTypeInput);

                System.Console.WriteLine("ENTER store products");
                var productsInput = StoreValidation.IsValidInput(Console.ReadLine());
                if(productsInput == -1)
                {
                    System.Console.WriteLine("Kindly enter numbers");
                    productsInput = StoreValidation.IsValidInput(Console.ReadLine());
                }
                products = StoreValidation.ValidateProducts(productsInput);

                Store store = actionsStore.CreateStore(storeName, storeNumber, storeType, products);
                actionsStore.SaveStoreChanges();    
                System.Console.WriteLine($"Your {storeName} has been created succesfully");
                DisplayProductsInterface.DisplayProducts(actionsStore);
                
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
        }
    }
}




