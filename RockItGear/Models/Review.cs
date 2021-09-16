using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RockItGear.Models
{
    public class Review
    {
        public string ReviewID { get; set; }
        
        [Required]
        public int ProductID { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerEmail { get; set; }

        [StringLength(10000), DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public System.DateTime DateCreated { get; set; }

    }
}