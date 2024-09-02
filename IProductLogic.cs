using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopTrue
{
    /// <summary>
    /// Defines operations for managing products
    /// </summary>
    internal interface IProductLogic
    {
        void AddProduct(Product product);

        List<Product> GetAllProducts();

        DogLeash GetDogLeashByName(string name);

        CatFood GetCatFoodByName(string name);

        List<string> GetOnlyInStockProducts();

        decimal GetTotalPriceOfInventory();
    }
}
