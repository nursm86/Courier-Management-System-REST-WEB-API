using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Courier_Management_REST_WEB_API.Models
{
    public class UserMetaData
    {
        public int Id { get; set; }
        [Required, MinLength(3)]
        public string UserName { get; set; }
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        [Required, MinLength(4)]
        public string Password { get; set; }
        [Required]
        public int UserType { get; set; }
        [Required]
        public int Status { get; set; }
        public string image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        
        [JsonIgnore, XmlIgnore]
        public virtual ICollection<Customer> Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore, XmlIgnore]

        public virtual ICollection<Employee_Problems> Employee_Problems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore, XmlIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore, XmlIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}