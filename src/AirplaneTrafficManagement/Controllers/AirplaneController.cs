using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirplaneTrafficManagement.Controllers
{
    public class AirplaneController : Controller
    {
        // GET: Airplane
        public ActionResult Index()
        {
            return View();
        }
    }
}