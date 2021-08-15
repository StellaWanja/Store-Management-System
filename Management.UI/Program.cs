using System;
using System.Threading.Tasks;
using Management.BusinessLogic;
using Management.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Management.UI
{
    class Program
    {
        private static IServiceProvider serviceProvider;

        static void Main(string[] args)
        {
            try
            {
                ConfigureServices();

                IBusinessLogicCustomer actionsCustomer = serviceProvider.GetRequiredService<IBusinessLogicCustomer>();

                IBusinessLogicStore actionsStore = serviceProvider.GetRequiredService<IBusinessLogicStore>();
                
                MainUI.DisplayDashboard(actionsCustomer, actionsStore);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to start application");
            }
        }

        private static void ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.AddScoped<IBusinessLogicCustomer, CustomerActions>();
            services.AddScoped<IBusinessLogicStore, StoreActions>();
            services.AddScoped<ICustomerDataStore, CustomerDataStore>();
            services.AddScoped<IStoreDataStore, StoreDataStore>();

            serviceProvider = services.BuildServiceProvider();
        }

    }
}
