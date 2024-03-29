﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeyawoPortfolio.Models;
using Microsoft.Ajax.Utilities;

namespace MeyawoPortfolio.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioEntities db = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult FuturePartial()
        {
            var values = db.TblFuture.ToList();
            return PartialView(values);
        }

        public PartialViewResult AboutPartial()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }

        public PartialViewResult ServicePartial()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult ProjectPartial()
        {

            var values = db.TblProject.ToList();
            return PartialView(values);

        }
        public PartialViewResult TestmonialPartial()
        {

            var values = db.TblTestimonial.ToList();
            return PartialView(values);

        }
        [HttpGet]
        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }
        [HttpPost]

        public PartialViewResult ContactPartial(TblContact p)

        {
            var value = db.TblContact.Add(p);
            value.SendDate = DateTime.Now;
            value.IsRead = false;
            db.SaveChanges();
            return PartialView(value);
        }
    }
}