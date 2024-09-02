using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopTrue
{
    /// <summary>
    /// Represents cat food with specific parameters
    /// </summary>
    internal class CatFood : Product
    {
        public double WeightPounds { get; set; }
        public bool IsKittenFood { get; set; }
    }
}
