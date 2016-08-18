using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace dWeb.Auger.Drilling.Models
{
    public class Maintenance
    {
        public Models.Search search { get; set; }
        public Models.WorkOrder workOrder { get; set; }
    }

    public class Search
    {
        public string SearchValue { get; set; }
        public string SearchBy { get; set; }
        public List<SelectListItem> SearchByList { get; set; }
        public Models.SearchResults Results { get; set; }
    }

    public class SearchResults
    {
        public List<MaintenanceRecord> Records { get; set; }
    }

    public class MaintenanceRecord
    {
        public long Id { get; set; }
        public string RigNumber { get; set; }
        public string MaintDescription { get; set; }
        public DateTime LastMaintDate { get; set; }
        public string Status { get; set; }
        public bool OilChanged { get; set; }
        public bool FiltersChanged { get; set; }
    }

    public class WorkOrder
    {
        public long Id { get; set; }
        public string RigNumber { get; set; }
        public List<SelectListItem> RigNumberList { get; set; }
        public Helpers.StatusType Status { get; set; }
        public string Assigned { get; set; }
        public List<SelectListItem> AssignedList { get; set; }
        public bool OilChange { get; set; }
        public bool FilterChange { get; set; }
        public string Request { get; set; }
        public DateTime LastMaintDate { get; set; }
        public DateTime LastOilChange { get; set; }
        public DateTime LastFilterChange { get; set; }
        public bool NotifyTracking { get; set; }
    }

    public class ViewWorkOrder
    {
        public long Id { get; set; }
        public RigInformation RigInfo { get; set; }
        public List<Part> Parts { get; set; }
        public Helpers.StatusType Status { get; set; }
        public string Assigned { get; set; }
        public DateTime AssignedDate { get; set; }
        public bool OilChange { get; set; }
        public bool FilterChange { get; set; }
        public string Request { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalHours { get; set; }
    }

    public class Part
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Helpers.PartReason Reason { get; set; }
        public decimal Cost { get; set; }
        public decimal Hours { get; set; }
    }

    public class RigInformation
    {
        public string RigNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public DateTime PurchasedDate { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - PurchasedDate.Year;
            }
        }
        public DateTime LastOilChange { get; set; }
        public DateTime LastFilterChange { get; set; }
    }
}