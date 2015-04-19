using ProductServiceClient.Models;
using ProductServiceClient.ProductServiceProxy;
using ProductServiceClient.Mappers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace ProductServiceClient.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult GetProduct()
        {
            ProductModel model = new ProductModel();

            using (ProductAggregatorServiceClient client = new ProductServiceProxy.ProductAggregatorServiceClient())
            {
                ProductMapper.MapProduct(model, client.GetProducts());
            }

            return View("ViewProducts",model.Products);
        }
	}
}