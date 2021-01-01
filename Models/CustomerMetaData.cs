using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Courier_Management_REST_WEB_API.Models
{
    public class CustomerMetaData
    {
        [Required,MinLength(3)]
        public string Name { get; set; }
        [Required,MinLength(11),MaxLength(14)]
        public string Contact { get; set; }
        [Required,MinLength(5)]
        public string Address { get; set; }
        [Required]
        public string SequrityQue { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int Id { get; set; }
        public int userId { get; set; }
        public virtual User User { get; set; }
    }
}