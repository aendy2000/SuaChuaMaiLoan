using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuaChuaMaiLoan.Models;

namespace SuaChuaMaiLoan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ShowActive = "HomeIndex";
            string filePathProduct = Server.MapPath("~/JsonModels/product.json");
            string jsonTextProduct = System.IO.File.ReadAllText(filePathProduct);
            List<Products> resultProduct = JsonConvert.DeserializeObject<List<Products>>(jsonTextProduct);

            if(resultProduct.Count < 8 )
                return View("Index", resultProduct.OrderByDescending(o => o.ID).Take(4));
            else
                return View("Index", resultProduct.OrderByDescending(o => o.ID).Take(8));
        }

        public ActionResult Product()
        {
            ViewBag.ShowActive = "HomeProduct";
            string filePathProduct = Server.MapPath("~/JsonModels/product.json");
            string jsonTextProduct = System.IO.File.ReadAllText(filePathProduct);
            List<Products> resultProduct = JsonConvert.DeserializeObject<List<Products>>(jsonTextProduct);

            return View("Product", resultProduct.OrderByDescending(o => o.ID).ToList());
        }

        [HttpPost]
        public ActionResult ProductDetail(int id)
        {
            string filePath = Server.MapPath("~/JsonModels/product.json");
            string jsonText = System.IO.File.ReadAllText(filePath);
            List<Products> result = JsonConvert.DeserializeObject<List<Products>>(jsonText);
            Products products = result.Find(p => p.ID == id);
            return PartialView("_HomeProductDetail", products);
        }

        public ActionResult About()
        {
            ViewBag.ShowActive = "HomeAbout";
            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.ShowActive = "HomeContact";
            return View("Contact");
        }
    }
}