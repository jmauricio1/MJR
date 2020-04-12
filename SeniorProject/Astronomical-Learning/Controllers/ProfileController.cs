﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Microsoft.AspNet.Identity;

namespace Astronomical_Learning.Controllers
{
    public class ProfileController : Controller
    {
        private ALContext db = new ALContext();
        

        // GET: Profile
        public ActionResult ProfilePage()
        {
            var userId = User.Identity.GetUserId();
            var user = db.AspNetUsers.Find(userId);

            ViewBag.UserName = user.UserName;
            ViewBag.FirstName = user.FirstName;
            ViewBag.LastName = StringInfo.GetNextTextElement(user.LastName, 0);
            ViewBag.State = user.StateProvince;
            return View();
        }
    }
}