using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SuperMarketBillingUI.Controllers
{
    public class ProductTbController : Controller
    {
        // GET: ProductTb
        public ActionResult Index()
        { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SuperMarketBillingUI.Models.ProductTb obj)
        {
            var obj2 = new Dictionary<string, string>()
        {
            { "ProductId",obj.ProductId.ToString()},
            {"ProductName",obj.ProductName },
                {"Category",obj.Category },
                {"DateOfManufacture",obj.DateOfManufacture.ToString() },
                {"Price",obj.Price.ToString() },
                {"Quantity",obj.Quantity.ToString() }
        };

            //  { StaffId = 10, Password = "12345" };
            //SuperMarketBillingUI.Models.ProductTb product;
            HttpClient client = new HttpClient();
            string url = "http://localhost:52903/api/ProductTbs";
            var content = new FormUrlEncodedContent(obj2);
            var response = client.PostAsync(url, content);
            //String op = "";
            ////.Text = response.ToString();
            //using (HttpContent cont = response.Result.Content) {
            //    Task<string> res = cont.ReadAsStringAsync();
            //    op = res.Result;
            //     JavaScriptSerializer js = new JavaScriptSerializer();
            //    product = js.Deserialize<Models.ProductTb>(op);

            //}
           // ViewBag.Message = String.Format("Successfull");
            
            return View();
        }

    }
}