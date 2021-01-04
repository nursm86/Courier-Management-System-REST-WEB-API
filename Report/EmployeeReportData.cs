using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Report
{
    public class EmployeeReportData
    {
        public string Name { get; set; }
        public int totalSentProduct { get; set; }
        public int totalReceivedProduct { get; set; }
        public int totalVerifiedUser { get; set; }
        public int totalInvalidUser { get; set; }
        public int totalBlockedUser { get; set; }
        public int TotalElectronisSent { get; set; }
        public int TotalMobilesSent { get; set; }
        public int TotalAccessoriesSent { get; set; }
        public int TotalPapersSent { get; set; }
        public int TotalPackagesSent { get; set; }
    }
}