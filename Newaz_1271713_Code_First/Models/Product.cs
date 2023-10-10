using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newaz_1271713_Code_First.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public int CategoryID { get; set; }

    }
}