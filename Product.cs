using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCart
{
    [Serializable]
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image_url { get; set; }
        public decimal price { get; set; }
    }
}