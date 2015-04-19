using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "imagee")]
        public string ImageUrl { get; set; }

        [DataMember(Name = "rating")]
        public decimal? Rating { get; set; }

        [DataMember(Name = "price")]
        public decimal? Price { get; set; }

        [DataMember(Name = "users")]
        public double? Users { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "last_update")]
        public DateTime LastUpdated { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "url")]
        public string ProductUrl { get; set; }

    }
}
