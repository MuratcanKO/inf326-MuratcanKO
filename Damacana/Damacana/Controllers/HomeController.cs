using Damacana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Damacana.Controllers
{
    public class HomeController : Controller
    {
        public static int IdCount = 4;
        public static List<Product> products = new List<Product>(){
            new Product()
            {
                Id = 1,
                Name = "Aquamarine Revenge | AK-47",
                Foto = "https://nbain21.files.wordpress.com/2014/10/gun.png",
                Price = (decimal)335.85,
            },
            new Product()
            {
                Id = 2,
                Name = "Water Elemental | Glock-18",
                Foto = "http://wcdn3.dataknet.com/static/resources/icons/set73/aabb0b87.png",
                Price = (decimal)25.95,
            },
            new Product()
            {
                Id = 3,
                Name = "Tiger Tooth | M9-Bayonet",
                Foto = "https://cdn1.iconfinder.com/data/icons/game-rpg/500/knife-512.png",
                Price = (decimal)1435.85,
            }
        };

        public ActionResult Index()
        {
            //Product product1 = new Product()
            //{
            //    Id = 1,
            //    Name = "Aquamarine Revenge - AK-47",
            //    Price = (decimal)335.85
            //};
            //Product product2 = new Product()
            //{
            //    Id = 2,
            //    Name = "Water Elemental - Glock-18",
            //    Price = (decimal)25.95
            //};
            //Product product3 = new Product()
            //{
            //    Id = 3,
            //    Name = "Tiger Tooth - M9-Bayonet",
            //    Price = (decimal)1435.85
            //};
            //List<Product> products = new List<Product>();
            //products.Add(product1);
            //products.Add(product2);
            //products.Add(product3);
            return View(products);
        }

        [HttpPost]
        public ActionResult AddProduct()
        {
            Product product = new Product()
            {
                Id = IdCount,
                Name = "",
                Foto = "https://cdn2.iconfinder.com/data/icons/freecns-cumulus/16/519660-164_QuestionMark-512.png",
                Price = (decimal)0
            };
            IdCount++;
            return View(product);
        }

        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {
            ViewBag.Message = "SaveProduct worked !";
            products.Add(product);
            return View(product);
        }

        public ActionResult ProductDetails(int id)
        {
            if (id < 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // This search will be far less ugly when we'll have a db
            foreach (Product product in HomeController.products)
                if (product.Id == id)
                    return View(product);

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult EditProduct(int id)
        {
            if (id < 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // This search will be far less ugly when we'll have a db
            foreach (Product product in HomeController.products)
                if (product.Id == id)
                    return View(product);

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult SaveModifiedProduct(Product product)
        {
            // This search will be far less ugly when we'll have a db
            foreach (Product p in HomeController.products)
                if (p.Id == product.Id)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.Foto = product.Foto;
                    return View("SaveProduct", p);
                }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}