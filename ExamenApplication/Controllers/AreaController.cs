using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExamenApplication.Models;

namespace ExamenApplication.Controllers
{
    public class AreaController : Controller
    {
        // GET: Area
        public ActionResult AreaIndex()
        {
            return View();
        }
    }
}