using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopTrue
{
    /// <summary>
    /// Represents dog leash with specific parameters
    /// </summary>
    internal class DogLeash : Product
    {
        public int LengthInches { get; set; }
        public String Material { get; set; }
    }
}
