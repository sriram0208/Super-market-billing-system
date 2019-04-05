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
    public class StaffLoginController : Controller
    {
        // GET: StaffLogin
        public ActionResult StaffLogin()
        {
            return View();
        }
        public ActionResult DashBoard(Models.StaffLoginTb obj)
        {
            var obj2 = new Dictionary<string, string>()
        {
            { "StaffId",obj.StaffId.ToString()},
         
                {"Password",obj.Password }
               
        };
            
            HttpClient client = new HttpClient();
            string url = "http://localhost:52903/api/StaffLoginTbs";
            var content = new FormUrlEncodedContent(obj2);
            var response = client.PostAsync(url, content);
            String op = "";
            string ret;
            using (HttpContent cont = response.Result.Content)
            {
                Task<string> res = cont.ReadAsStringAsync();
                op = res.Result;
                JavaScriptSerializer js = new JavaScriptSerializer();
                //product = js.Deserialize<Models.ProductTb>(op);
                ret = js.Deserialize<string>(op);
            }
            if (ret == "True")
            {
                Session["StaffId"] = obj.StaffId;
           
                return View();//redirect to dashboard
            }
                
            else
                return View("StaffLogin/StaffLogin");//same page with alert
        }

        public ActionResult Billing()
        { 
            return View();
        }

        public ActionResult BilledProductsView(int ProductId)
        {
        ////    var obj2 = new Dictionary<string, string>()
        ////{
        ////    { "ProductId",obj.ProductId.ToString()},

        ////        {"Quantity",obj.Quantity.ToString() }

        ////};
            //SuperMarketBillingUI.Models.BilledProductsTb obj = new SuperMarketBillingUI.Models.BilledProductsTb();
            HttpClient client = new HttpClient();
            string url = "http://localhost:52903/api/ProductTbs/1";
          // var content = new FormUrlEncodedContent(obj2);
            var response = client.GetAsync(url);
            String op = "";
            Models.ProductTb ret;
            using (HttpContent cont = response.Result.Content)
            {
                Task<string> res = cont.ReadAsStringAsync();
                op = res.Result;
                JavaScriptSerializer js = new JavaScriptSerializer();
                //product = js.Deserialize<Models.ProductTb>(op);
                ret = js.Deserialize<Models.ProductTb>(op);
            }
            return View(ret);
        }
    }
}