using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class DashboardController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.IsNotReadMessageCount = db.TblContact.Where(x => x.IsRead == false).Count();
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.testimonialCount = db.TblTestimonial.Count();
            
            return View();
        }
    }
}