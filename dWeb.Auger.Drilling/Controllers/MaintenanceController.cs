using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dWeb.Auger.Drilling.Controllers
{
    public class MaintenanceController : Controller
    {
        // GET: Maintenance
        public ActionResult Index()
        {

            return View(new Models.Maintenance() {
                search = new Models.Search()
                {
                    SearchByList = GetSearchBy(),
                    Results = new Models.SearchResults()
                    {
                        Records = new List<Models.MaintenanceRecord>()
                    }

                },
                workOrder = new Models.WorkOrder()
                {
                    RigNumberList = GetFakeRigs(),
                    AssignedList = GetFakeAssigned(),
                    NotifyTracking = true
                }
            });
        }

        public ActionResult Record(string record)
        {
            //Go get the record that is requested.
            string CostHours;
            List<Models.Part> parts = GetFakeParts(long.Parse(record), out CostHours);
            string[] CostSplit = CostHours.Split(',');
            return View(new Models.ViewWorkOrder()
            {
                Id = long.Parse(record),
                RigInfo = new Models.RigInformation()
                {
                    RigNumber = "67TF787",
                    Make = "Crawler Mount",
                    Model = "1100",
                    PurchasedDate = DateTime.Parse("11/12/2010"),
                    LastOilChange = DateTime.Parse("12/21/2015"),
                    LastFilterChange = DateTime.Parse("10/15/2015")
                },
                Status = Helpers.StatusType.Working,
                Assigned = "John H.",
                AssignedDate = DateTime.Parse("08/01/2016"),
                OilChange = true,
                FilterChange = false,
                Request = "This rig had clogged filters and was due oil change!",
                TotalCost = decimal.Parse(CostSplit[0]),
                TotalHours = decimal.Parse(CostSplit[1]),
                Parts = parts
            });
        }

        [HttpPost]
        public ActionResult SearchFor(Models.Search model)
        {
            Models.Maintenance mModel = new Models.Maintenance();
            model.Results = new Models.SearchResults()
            {
                Records = GetFakeList()
            };
            model.SearchByList = GetSearchBy();
            //model.SearchBy = string.Empty;
            
            mModel.search = model;
            mModel.workOrder = new Models.WorkOrder() {
                RigNumberList = GetFakeRigs(),
                AssignedList = GetFakeAssigned(),
                NotifyTracking = true
            };

            return View("Index", mModel);
        }

        public ActionResult EditRecord(string record)
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewEditWorkOrderSubmit(Models.WorkOrder model)
        {
            return RedirectToAction("Index");
        }

        public List<SelectListItem> GetFakeAssigned()
        {
            List<SelectListItem> sItems = new List<SelectListItem>();
            string[] Items = { "John", "Jake", "Russel", "Mike", "Billy Bob", "Mister Fix It" };
            foreach (string s in Items)
            {
                sItems.Add(new SelectListItem()
                {
                    Text = s,
                    Value = s
                });
            }

            return sItems;
        }
        public List<SelectListItem> GetFakeRigs()
        {
            List<SelectListItem> sItems = new List<SelectListItem>();
            string[] Items = { "1111111", "2222222", "3333333", "4444444", "5555555", "6666666" };
            foreach (string s in Items)
            {
                sItems.Add(new SelectListItem()
                {
                    Text = s,
                    Value = s
                });
            }

            return sItems;
        }

        private List<Models.MaintenanceRecord> GetFakeList()
        {
            List<Models.MaintenanceRecord> mRecords = new List<Models.MaintenanceRecord>();
            mRecords.Add(new Models.MaintenanceRecord() {
                Id = 0000001,
                RigNumber = "5555555",
                MaintDescription = "This rig had clogged filters and was due oil change!",
                LastMaintDate = DateTime.Parse("07/07/2016"),
                Status = "Closed",
                OilChanged = true,
                FiltersChanged = false
            });

            return mRecords;
        }

        private List<SelectListItem> GetSearchBy()
        {
            List<SelectListItem> sItems = new List<SelectListItem>();
            string[] Items = { "Rig Number", "Last Maintenance Date", "Last Oil Change", "Last Hydro-Filter Change", "Status", "Work Order Number" };
            foreach (string s in Items)
            {
                sItems.Add(new SelectListItem()
                {
                    Text = s,
                    Value = s
                });
            }

            return sItems;
        }

        private List<Models.Part> GetFakeParts(long id, out string CostHours)
        {
            List<Models.Part> PartsList = new List<Models.Part>();
            decimal Hours = 0;
            decimal Cost = 0;
            for (int i = 0; i < 2; i++)
            {
                PartsList.Add(new Models.Part()
                {
                    Number = "67TTF8U",
                    Name = "Oil Filter",
                    Description = "Oil Filter for Rig",
                    Reason = Helpers.PartReason.Requested,
                    Cost = decimal.Parse("45.23"),
                    Hours = decimal.Parse(".4")
                });
            }

            foreach (Models.Part p in PartsList) {
                Hours = Hours + p.Hours;
                Cost = Cost + p.Cost;
            }
            CostHours = string.Format("{0},{1}", Cost, Hours);

            return PartsList;
        }
    }
}