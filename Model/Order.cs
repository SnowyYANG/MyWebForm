using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebForm.Model
{
    public class Order
    {
        public int UserId { get; set; }
        public List<OrderItem> Items { get; private set; }
        public int State { get; set; }
    }
}
