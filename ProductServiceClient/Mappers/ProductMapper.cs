using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ProductServiceClient.Models;
using ProductServiceClient.ProductServiceProxy;

namespace ProductServiceClient.Mappers
{
    public static class ProductMapper
    {
        public static void MapProduct(this ProductModel model, IEnumerable<Product> products )
        {
            model.Products = new List<ProductModel.Product>();

            foreach (Product p in products)
            {
                ProductModel.Product product = new ProductModel.Product();
                product.Name = p.name;
                product.Price = p.price;
                product.Rating = p.rating;
                product.Description = p.description;
                product.Users = p.users;

                model.Products.Add(product);
            }
        }
    }
}