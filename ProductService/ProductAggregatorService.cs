using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple)]


    public class ProductAggregatorService : IProductAggregatorService
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return ProductHelper.Instance.Products;
            }

            catch (Exception ex)
            {
                ServiceFault fault = new ServiceFault();
                fault.Result = false;
                fault.Message = ex.Message;
                fault.Description = "error occurred while getting the products";

                throw new FaultException<ServiceFault>(fault);
            }
        }

        /// <summary>
        /// Return the product if there is a partial match on any of the products
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts(Product product)
        {
            try
            {
                return ProductHelper.Instance.Products.Where(p =>
                    {
                        bool retVal = true;
                        if (!string.IsNullOrEmpty(product.Name))
                        {
                            retVal = p.Name == product.Name;
                        }
                        if (product.Price != null)
                        {
                            retVal = p.Price == product.Price;
                        }
                        if (product.Rating != null)
                        {
                            retVal = p.Rating == product.Rating;
                        }
                        if (product.Users != null)
                        {
                            retVal = p.Users == product.Users;
                        }
                        if (!string.IsNullOrEmpty(product.Type))
                        {
                            retVal = p.Type == product.Type;
                        }
                        if (!string.IsNullOrEmpty(product.Description))
                        {
                            retVal = p.Description == product.Description;
                        }
                        return retVal;
                    }
                   );
            }

            catch (Exception ex)
            {
                ServiceFault fault = new ServiceFault();
                fault.Result = false;
                fault.Message = ex.Message;
                fault.Description = "error occurred while getting the products";
                throw new FaultException<ServiceFault>(fault);
            }
        }
        /// <summary>
        /// Service to filter the results, ideally this can be done at the UI layer.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="rating"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<Product> FilterProducts(decimal? price, decimal? rating, string type)
        {
            try
            {
                return ProductHelper.Instance.Products.Where(p => p.Price == price || price == null)
                                                      .Where(p => p.Rating == rating || rating == null)
                                                      .Where(p => p.Type == type || string.IsNullOrEmpty(type));
            }

            catch (Exception ex)
            {
                ServiceFault fault = new ServiceFault();
                fault.Result = false;
                fault.Message = ex.Message;
                fault.Description = "error occurred while getting the products";
                throw new FaultException<ServiceFault>(fault);
            }
  
        }

        /// <summary>
        /// Gets the product data by page number
        /// </summary>
        /// <param name="currIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Product> GetProductsByPageIndex(int currIndex, int pageSize)
        {
            try
            {
                return ProductHelper.Instance.Products.Skip(currIndex).Take(pageSize);
            }

            catch (Exception ex)
            {
                ServiceFault fault = new ServiceFault();
                fault.Result = false;
                fault.Message = ex.Message;
                fault.Description = "error occurred while getting the products";
                throw new FaultException<ServiceFault>(fault);
            }
  
        }
    }
}
