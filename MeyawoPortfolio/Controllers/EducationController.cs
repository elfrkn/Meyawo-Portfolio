using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;

namespace MeyawoPortfolio.Controllers
{
    public class EducationController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblEducation.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(TblEducation p)
        {
            db.TblEducation.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = db.TblEducation.Find(id);
            db.TblEducation.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = db.TblEducation.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEducation(TblEducation p)
        {
            var value = db.TblEducation.Find(p.EducationID);
            value.Title1 = p.Title1;
            value.Title2 = p.Title2;
            value.GNO = p.GNO;
            value.Date = p.Date;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}