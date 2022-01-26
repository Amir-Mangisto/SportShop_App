using SportShop_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop_App.Controllers
{
    public class ClothingController : Controller
    {
        ShoesContextDataContext ClothingContextDataContext = new ShoesContextDataContext();
        // GET: Clothing
        public ActionResult Index()
        {
            List<Clothing> cloths = ClothingContextDataContext.Clothings.Where(clothing => clothing.TypeOfCloths == "shirt").ToList();
            return View(cloths);
        }
        public ActionResult GetLongShirts()
        {
            List<Clothing> longShirts = ClothingContextDataContext.Clothings.Where(clothing => clothing.IsShort == false).ToList();
            return View(longShirts);
        }
        public ActionResult GetShortShirts()
        {
            List<Clothing> shortShirts = ClothingContextDataContext.Clothings.Where(clothing => clothing.TypeOfCloths == "shirt" && clothing.IsShort == true).ToList();
            return View(shortShirts);
        }
        public ActionResult GetDryfitShirts()
        {
            List<Clothing> dryfitShirts = ClothingContextDataContext.Clothings.Where(clothing => clothing.IsDryfit == true && clothing.TypeOfCloths == "shirt").ToList();
            return View(dryfitShirts);
        }
        public ActionResult GetClothingTable()
        {
            List<Clothing> ClothingTable = ClothingContextDataContext.Clothings.ToList();
            return View(ClothingTable);
        }
        public ActionResult OrderByPrice()
        {
            List<Clothing> orderList = ClothingContextDataContext.Clothings.Where(clothing => clothing.TypeOfCloths == "shirt" || clothing.TypeOfCloths == "jacket").OrderBy(clothing=>clothing.Price).ToList();   
            return View(orderList);
        }


    }
}