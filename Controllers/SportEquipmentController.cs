using SportShop_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop_App.Controllers
{
    public class SportEquipmentController : Controller
    {
        ShoesContextDataContext SportEqContextDataContext = new ShoesContextDataContext();

        // GET: SportEquipment
        public ActionResult GetAllSportEQ()
        {
            List<SportEQ> eqList = SportEqContextDataContext.SportEQs.ToList();
            return View(eqList);
        }
        public ActionResult GetManagerTable()
        {
            List<SportEQ> managerTable = SportEqContextDataContext.SportEQs.ToList();
            return View(managerTable);
        }
        public ActionResult GetFootballEquipment()
        {
            List<SportEQ> footballList=SportEqContextDataContext.SportEQs.Where(sportItem=>sportItem.SportType == "Football").ToList();
            return View(footballList);
        }
        public ActionResult GetNbaEquipment()
        {
            List<SportEQ> NbaList = SportEqContextDataContext.SportEQs.Where(sportItem => sportItem.SportType == "NBA").ToList();
            return View(NbaList);
        }
        public ActionResult GetSortedEquipment()
        {
            List<SportEQ> sortedList = SportEqContextDataContext.SportEQs.Where(sportItem => sportItem.SportType == "NBA"|| sportItem.SportType=="Football").OrderBy(sportItem=>sportItem.Price).ToList();
            return View(sortedList);
        }
    }
}