using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dWeb.Auger.Drilling.Controllers
{
    public class DTTController : Controller
    {
        // GET: DTT
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InService(string RigNumber)
        {
            return View();
        }
    }
}