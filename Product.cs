using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopTrue
{
    /// <summary>
    /// Represents product with basic details
    /// </summary>
    internal class Product
    {
        public String Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public String Description { get; set; }
    }
}
