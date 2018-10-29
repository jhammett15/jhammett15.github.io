﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HWK5.DAL;
using HWK5.Models;

namespace HWK5.Controllers
{
    public class HomeController : Controller
    {
        private RequestContext db = new RequestContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RequestForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestForm([Bind(Include = "ID, FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, Explanation")] Request request)
        {
            if(ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("ViewRequests");
            }

            return View(request);
        }

        public ActionResult ViewRequests()
        {
            return View(db.Requests.ToList());
        }
    }
}