using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newaz_1271713_Code_First.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }
        public OrderMaster OrderMaster { get; set; }

        public int ProductID { get; set; }

        [Required(ErrorMessage ="Must be filled")]
        public int Quantity { get; set; }
        public decimal Rate { get; set; }
    }
}