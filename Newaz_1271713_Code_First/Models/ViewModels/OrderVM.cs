using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newaz_1271713_Code_First.Models.ViewModels
{
    public class OrderVM
    {
 
        public int OrderID { get; set; }
        public string OrderNote { get; set; }
        public DateTime OrderDate { get; set; }
        public string AddressProofImage { get; set; }
        public Nullable<bool> Terms { get; set; }
        public int OrderDetailID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Rate { get; set; }

    }
}