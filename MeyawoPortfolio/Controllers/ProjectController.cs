using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;
using Microsoft.Ajax.Utilities;


namespace MeyawoPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
         
        public ActionResult Index()
        {
            var values = db.TblProject.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            List<SelectListItem> values = (from x in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();


            ViewBag.v = values;
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult UpdateProject(int id)
        {
            List<SelectListItem> values1 = (from x in db.TblCategory.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();


            ViewBag.v = values1;
            var values = db.TblProject.Find(id);
            return View(values);
        }

        [HttpPost]

        public ActionResult UpdateProject(TblProject p)
        {
            var values = db.TblProject.Find(p.ProjectID);
            values.Title = p.Title;
            values.ProjectUrl = p.ProjectUrl;
            values.Desciption = p.Desciption;
            values.ProjectCategory = p.ProjectCategory;
            values.ImageUrl = p.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }        
       
    }
}