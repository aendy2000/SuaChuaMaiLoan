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

            string filePathFlavour = Server.MapPath("~/JsonModels/flavour.json");
            string jsonTextFlavour = System.IO.File.ReadAllText(filePathFlavour);
            List<Flavour> resultFlavour = JsonConvert.DeserializeObject<List<Flavour>>(jsonTextFlavour);
            Session["lstFlavour"] = resultFlavour;

            string filePathCategories = Server.MapPath("~/JsonModels/categories.json");
            string jsonTextCategories = System.IO.File.ReadAllText(filePathCategories);
            List<Categories> resultCategories = JsonConvert.DeserializeObject<List<Categories>>(jsonTextCategories);
            Session["lstCategories"] = resultCategories;

            return View("Index", resultProduct);
        }

        public ActionResult Product()
        {
            ViewBag.ShowActive = "HomeProduct";
            string filePathProduct = Server.MapPath("~/JsonModels/product.json");
            string jsonTextProduct = System.IO.File.ReadAllText(filePathProduct);
            List<Products> resultProduct = JsonConvert.DeserializeObject<List<Products>>(jsonTextProduct);

            string filePathFlavour = Server.MapPath("~/JsonModels/flavour.json");
            string jsonTextFlavour = System.IO.File.ReadAllText(filePathFlavour);
            List<Flavour> resultFlavour = JsonConvert.DeserializeObject<List<Flavour>>(jsonTextFlavour);
            Session["lstFlavour"] = resultFlavour;

            string filePathCategories = Server.MapPath("~/JsonModels/categories.json");
            string jsonTextCategories = System.IO.File.ReadAllText(filePathCategories);
            List<Categories> resultCategories = JsonConvert.DeserializeObject<List<Categories>>(jsonTextCategories);
            Session["lstCategories"] = resultCategories;

            return View("Product", resultProduct);
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