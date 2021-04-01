

namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ItemList
    {
        public int ItemID { get; set; }

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<double> Price { get; set; }
        public string Description { get; set; }
        public Nullable<double> Tax { get; set; }
    }
}
