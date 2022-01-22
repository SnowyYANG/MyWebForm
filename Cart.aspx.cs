using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleCart
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string GetProducts(string ids)
        {
            var r = new Random();
            var result = ids.Split(',').Select((i) => new Product() { id = int.Parse(i), image_url = $"/upload/{i}.jpg", price = (decimal)(r.NextDouble() * 100d), title = "Bread " + i }).ToArray();
            var response = JsonConvert.SerializeObject(result);
            return response;
        }
    }
}