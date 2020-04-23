using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class GamesAndQuizzesController : Controller
    {
        // GET: GamesAndQuizzes
        public ActionResult QuizSelection()
        {
            return View();
        }

        public ActionResult Quiz_1()
        {
            return View();
        }
    }
}