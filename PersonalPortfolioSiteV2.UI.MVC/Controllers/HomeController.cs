﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalPortfolioSiteV2.UI.MVC.Models;

namespace PersonalPortfolioSiteV2.UI.MVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }


    }
}