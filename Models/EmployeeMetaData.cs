using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Courier_Management_REST_WEB_API.Models
{
    public class EmployeeMetaData
    {
        [Required,MinLength(3)]
        public string Name { get; set; }
        public Nullable<System.DateTime> Joining_date { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        [Required]
        public Nullable<double> Salary { get; set; }
        [Required]
        public Nullable<double> Bonus { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Nullable<int> Designation { get; set; }
        public Nullable<int> Branch_id { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public int Id { get; set; }
        public string Blood_Group { get; set; }
        public string Qualification { get; set; }
        public int userId { get; set; }
        [JsonIgnore, XmlIgnore]
        public virtual Branch Branch { get; set; }
        public virtual User User { get; set; }
    }
}