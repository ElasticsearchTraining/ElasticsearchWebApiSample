using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElasticsearchWebApiSample.Models
{
    public class Product
    {
        public Product(int id, string name, string brand, double price)
        {
            this.id = id;
            this.name = name;
            this.brand = brand;
            this.price = price;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public double price { get; set; }

    }
}