using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Report
{
    public class CustomerReportData
    {
        public string Name { get; set; }
        public int TotalFinishedDelivery { get; set; }
        public int TotalPendingDelivery { get; set; }
        public int TotalElectronisSent{ get; set; }
        public int TotalMobilesSent { get; set; }
        public int TotalAccessoriesSent { get; set; }
        public int TotalPapersSent { get; set; }
        public int TotalPackagesSent { get; set; }
        public double totalSpentMoney { get; set; }
    }
}