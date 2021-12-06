using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebForm.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PaswordHash { get; set; }
        public string RealName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
