﻿using System.Collections.Generic;
using System.Web.Mvc;
using WebAPIwithMSMQ.Models;

namespace WebAPIwithMSMQ.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            
            return View();
        }
    }
}