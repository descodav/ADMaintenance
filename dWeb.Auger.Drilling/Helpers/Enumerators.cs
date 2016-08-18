using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dWeb.Auger.Drilling.Helpers
{
    public enum StatusType
    {
        Open = 0,
        Assigned = 1,
        Working = 2,
        Closed = 3
    }

    public enum PartReason
    {
        Defective = 0,
        Broken = 1,
        HaveToo = 2,
        Required = 3,
        TimeRequired = 4,
        Requested = 5
    }

    public class Enumerators
    {
    }
}