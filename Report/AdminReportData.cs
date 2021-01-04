using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Report
{
    public class AdminReportData
    {
        public string Name { get; set; }
        public int TotalManager { get; set; }
        public int TotalDriver { get; set; }
        public int TotalDeliveryBoy { get; set; }
        public string HighestPaidManager { get; set; }
        public double HighestPay { get; set; }
        public int TotalBranch { get; set; }
    }
}