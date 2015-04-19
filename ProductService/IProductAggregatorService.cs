using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductAggregatorService" in both code and config file together.
    [ServiceContract]
    public interface IProductAggregatorService
    {
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        IEnumerable<Product> GetProducts();

        /// <summary>
        /// Return the product if there is a partial match on any of the products
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [OperationContract(Name="SearchProducts")]
        [FaultContract(typeof(ServiceFault))]
        IEnumerable<Product> GetProducts(Product product);

        /// <summary>
        /// Service to filter the results, ideally this can be done at the UI layer.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="rating"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        IEnumerable<Product> FilterProducts(decimal? price, decimal? rating, string type);

        /// <summary>
        /// Gets the product data by page number
        /// </summary>
        /// <param name="currIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(ServiceFault))]
        IEnumerable<Product> GetProductsByPageIndex(int currIndex, int pageSize);
    }
}
