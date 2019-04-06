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
        public ActionResult CustomerRegister(string CustomerId,String CustomerName)
        {
            //string CustomerId = Request["CustomerId"];
            DateTime date=DateTime.Now;
            //date.ToShortDateString();
            var custobj = new Dictionary<string, string>()
            {
                {"CustomerId",CustomerId },
                {"CustomerName",CustomerName },
                {"Points","0" }
            };
            HttpClient client2 = new HttpClient();
            string url2 = "http://localhost:52903/api/CustomerTbs";
            var content2 = new FormUrlEncodedContent(custobj);
            var response2 = client2.PostAsync(url2, content2);
            var obj = new Dictionary<string, string>()
            {
                {"CustomerId",CustomerId },
                {"Amount","0" },
                {"Date",date.ToString() }
               
            };
            HttpClient client = new HttpClient();
            string url = "http://localhost:52903/api/BillingTables";
            var content = new FormUrlEncodedContent(obj);
            var response = client.PostAsync(url, content);
             string op = "";
            Models.BillingTable ret;
            using (HttpContent cont = response.Result.Content)
            {
                Task<string> res = cont.ReadAsStringAsync();
                op = res.Result;
                JavaScriptSerializer js = new JavaScriptSerializer();
                //product = js.Deserialize<Models.ProductTb>(op);
                ret = js.Deserialize<Models.BillingTable>(op);
            }
            Session["BillId"] = ret.BillId;
            return View("Billing");
        }
        public ActionResult Billing()
        {
           return View();
        }

        public ActionResult BilledProductsView(Models.ProductTb obj)
        {
            var obj3 = new Dictionary<string, string>()
            {
                
                { "ProductId",obj.ProductId.ToString()},

                    {"Quantity",obj.Quantity.ToString() }

            };
            HttpClient client = new HttpClient();
            string url = "http://localhost:52903/api/ProductTbs/"+obj.ProductId;
          // var content = new FormUrlEncodedContent(obj3);
            var response = client.GetAsync(url);

            string op = "";
            Models.ProductTb ret;
            using (HttpContent cont = response.Result.Content)
            {
                Task<string> res = cont.ReadAsStringAsync();
                op = res.Result;
                JavaScriptSerializer js = new JavaScriptSerializer();
                //product = js.Deserialize<Models.ProductTb>(op);
                ret = js.Deserialize<Models.ProductTb>(op);
            }
            ViewBag.ProductId = ret.ProductId;
            ViewBag.ProductName = ret.ProductName;
            ViewBag.Price = ret.Price;
            var obj2 = new Dictionary<string, string>()
            {
                {"BillId",Session["BillId"].ToString() },
                { "ProductId",obj.ProductId.ToString()},

                    {"Quantity",obj.Quantity.ToString() }

            };
            HttpClient client2 = new HttpClient();
            string url2 = "http://localhost:52903/api/BilledProductsTbs";
            var content2 = new FormUrlEncodedContent(obj2);
            var response2 = client.PostAsync(url2, content2);

            return View("Billing");
        }
    }
}