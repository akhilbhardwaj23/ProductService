using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductServiceClient.Models
{
    public class ProductModel
    {
        public decimal? Rating { get; set; }
        public decimal? Price { get; set; }
        public string Type { get; set; }

        public List<Product> Products;

        public class Product
        {
            public string Id { get; set; }

            public string Name { get; set; }

            public string ImageUrl { get; set; }

            public decimal Rating { get; set; }

            public decimal Price { get; set; }

            public double Users { get; set; }

            public string Type { get; set; }

            public DateTime LastUpdated { get; set; }

            public string Description { get; set; }

            public string ProductUrl { get; set; }
        }
    }
}