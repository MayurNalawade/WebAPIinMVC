using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcItems
    {
        public int ItemID { get; set; }
        [Required(ErrorMessage = "Please Enter Item code...")]

        public string ItemCode { get; set; }
        [Required(ErrorMessage = "Please Enter Item Name...")]

        public string ItemName { get; set; }
        [Required(ErrorMessage = "Please Enter Item Price...")]

        public Nullable<double> Price { get; set; }

        public string Description { get; set; }
        [Required(ErrorMessage = "Please Enter Tax percent...")]

        public Nullable<double> Tax { get; set; }
    }
}