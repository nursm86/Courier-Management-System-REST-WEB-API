using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Models
{
    public class CustomerMetaData
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string SequrityQue { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int Id { get; set; }
        public int userId { get; set; }
        public virtual User User { get; set; }
    }
}