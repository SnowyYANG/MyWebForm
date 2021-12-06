using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCart
{
    public partial class _Default : Page
    {
        public List<Product> Products { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Products = new List<Product>()
            {
                new Product(){Id=1,Title="Aweson 1", ImageUrl="/upload/product1.jpg", Price=99.9M, CategoryId=1},
                new Product(){Id=1,Title="Tiny 2", ImageUrl="/upload/product2.jpg", Price=1.5M, CategoryId=1}
            };
        }

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            return new List<Product>()            {
                new Product(){Id=1,Title="Aweson 1", ImageUrl="/upload/product1.jpg", Price=99.9M, CategoryId=1},
                new Product(){Id=1,Title="Tiny 2", ImageUrl="/upload/product2.jpg", Price=1.5M, CategoryId=1}
            }.AsQueryable();
        }
    }
}