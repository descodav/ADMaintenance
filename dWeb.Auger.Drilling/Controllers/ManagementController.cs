using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dWeb.Auger.Drilling.Controllers
{
    public class ManagementController : Controller
    {
        // GET: Management
        public ActionResult Index()
        {
            return View(new Models.ManagementViewModel()
            {
                regModel = new Models.RegisterViewModel()
                {
                    UserRoles = GetFakeRoles()
                }
            });
        }

        public static List<SelectListItem> GetFakeRoles()
        {
            List<SelectListItem> FakeRoles = new List<SelectListItem>();
            Dictionary<string, string> Roles = new Dictionary<string, string>()
            {
                { "1", "Administrator" }, {"2", "Office" }, {"3", "Operator" }, {"4", "Maintenance" }, {"5", "Standard" }
            };
            foreach (var role in Roles)
            {
                FakeRoles.Add(new SelectListItem()
                {
                    Selected = (role.Key == "5") ? true : false,                       
                    Text = role.Value,
                    Value = role.Key
                });
            }

            return FakeRoles;
        }
    }
}