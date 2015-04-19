using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;


namespace ProductService
{
    //Singleton instance to feth the json data

    public sealed class ProductHelper
    {
        //Instance of the class
        private static ProductHelper instance;
        private static readonly object lockInstace = new object();

        private ProductHelper()
        {
        }

        
        public static ProductHelper Instance
        {
            get
            {
                lock (lockInstace)
                {
                    if (instance == null)
                    {
                        instance = new ProductHelper();
                    }
                    return instance;
                }
            }
        }

        private IEnumerable<Product> _products;

        public IEnumerable<Product> Products
        {
            get
            {
                //Products should be lazy loaded in memory if does not exist already.
                if (_products == null)
                {
                    try
                    {
                        using (var wc = new WebClient())
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            string jsonString = wc.DownloadString("http://mcafee.0x10.info/api/app?type=json");
                            _products = serializer.Deserialize<Product[]>(jsonString);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                return _products;
            }

        }

    }
}
