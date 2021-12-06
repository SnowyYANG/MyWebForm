using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCart
{
    public class OrderItem
    {
        public int ProductId { get; set; }
        public string CachedTitle { get; set; }
        public string CachedImage { get; set; }
        public string CachedDetailHtml { get; set; }
        public decimal CachedPrice { get; set; }
    }
}
