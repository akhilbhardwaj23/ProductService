using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ProductServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost productServiceHost = null;
            try
            {
                //Instantiate ServiceHost
                productServiceHost = new ServiceHost(typeof(ProductService.ProductAggregatorService));
                //Open
                productServiceHost.Open();
                Console.WriteLine("Service is running ....");
                Console.ReadKey();                
            }

            catch (Exception ex)
            {
                productServiceHost = null;
                Console.WriteLine("There is an issue with ProductService" + ex.Message);
            }
        }
    }
}
