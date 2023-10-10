using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newaz_1271713_Code_First.Models
{
    public class OrderMaster
    {

        [Key]
        public int OrderID { get; set; }
        [StringLength(50)]
        public string OrderNote { get; set; }

        public DateTime OrderDate { get; set; }
        public string AddressProofImage { get; set; }
        public Nullable<bool> Terms { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}