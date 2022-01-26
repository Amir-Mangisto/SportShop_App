using SportShop_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop_App.Controllers
{
    public class ShoesController : Controller
    {
        static string connectionString = "Data Source=.;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        ShoesContextDataContext shoesContextDataContext = new ShoesContextDataContext(connectionString);
        // GET: Shoes
        public ActionResult GetAllShoes()
        {
            return View(shoesContextDataContext.Shoes.ToList());
        }
        public ActionResult GetShoesOnSale()
        {
            return View(shoesContextDataContext.Shoes.Where(shoeItem=>shoeItem.OnSale == true).ToList());
        }
        public ActionResult GetShoesTable()
        {
            return View(shoesContextDataContext.Shoes.ToList());
        }
    }
}