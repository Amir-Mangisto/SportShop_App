using SportShop_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop_App.Controllers
{
    public class PantsController : Controller
    {
        ShoesContextDataContext PantsContextDataContext = new ShoesContextDataContext();

        // GET: Pants
        public ActionResult GetAllPants()
        {
            List<Clothing> pantsList = PantsContextDataContext.Clothings.Where(pantsItem => pantsItem.TypeOfCloths == "pants" || pantsItem.TypeOfCloths == "long pants").ToList();
            return View(pantsList);
        }
        public ActionResult GetManagerTable()
        {
            List<Clothing> managerList = PantsContextDataContext.Clothings.Where(item=>item.TypeOfCloths == "pants" || item.TypeOfCloths == "long pants").ToList();
            return View(managerList);
        }
        public ActionResult GetLongPants()
        {
            List<Clothing> longPants=PantsContextDataContext.Clothings.Where(pantsItem=>pantsItem.TypeOfCloths=="long pants").ToList();
            return View(longPants);
        }
        public ActionResult GetShortPants()
        {
            List<Clothing> shortPants = PantsContextDataContext.Clothings.Where(pantsItem => pantsItem.TypeOfCloths == "pants").ToList();
            return View(shortPants);
        }
        public ActionResult GetDryfitPants()
        {
            List<Clothing> dryfitPants=PantsContextDataContext.Clothings.Where(pantsItem=>pantsItem.TypeOfCloths == "pants" || pantsItem.TypeOfCloths == "long pants" && pantsItem.IsDryfit == true).ToList();
            return View(dryfitPants);
        }
        public ActionResult GetOrderByPrice()
        {
            List<Clothing> orderByPricePants = PantsContextDataContext.Clothings.Where(pantsItem => pantsItem.TypeOfCloths == "pants" || pantsItem.TypeOfCloths == "long pants").OrderBy(pantsItem=>pantsItem.Price).ToList();
            return View(orderByPricePants);
        }

    }
}