using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PetShopTrue
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeash;
        private Dictionary<string, CatFood> _catFood;

        public ProductLogic()
        {
            _products = new List<Product>
            {
                new DogLeash 
                {
                    Name = "Happy Leash",
                    Price = 9.99m,
                    Description = "Fun for you and your dog!",
                    LengthInches = 60,
                    Material = "Leather",
                    Quantity = 1                       
                },
                new CatFood
                {
                    Name = "Hungry Kat",
                    Price = 6.89m,
                    Description = "Your cat will love it!",
                    WeightPounds = 8.4d,
                    IsKittenFood = false,
                    Quantity = 0
                },
                new DogLeash
                {
                    Name = "Walk Time!",
                    Price = 12.59m,
                    Description = "Bark for joy!",
                    LengthInches = 60,
                    Material = "Leather",
                    Quantity = 2
                }
            };

            _dogLeash = new Dictionary<string, DogLeash>();
            _catFood = new Dictionary<string, CatFood>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
            
            if (product is DogLeash dogLeash)
            {
                _dogLeash.Add(dogLeash.Name, dogLeash);
            }
            else if (product is CatFood catFood)
            {
                _catFood.Add(catFood.Name, catFood);
            }
        }

        public List<Product> GetAllProducts()
        {
            return _products;
        }

        public DogLeash GetDogLeashByName(string name)
        {
            try
            {
                _dogLeash.ContainsKey(name);
                return _dogLeash[name];
            }
            catch (Exception ex)
            {
                return null!;
            }
        }

        public CatFood GetCatFoodByName(string name)
        {
            try
            {
                _catFood.ContainsKey(name);
                return _catFood[name];
            }
            catch (Exception ex)
            {
                return null!;
            }
        }

        public List<string> GetOnlyInStockProducts()
        {
            return _products
                .Where(x => x.Quantity > 0)
                .Select(x => x.Name)
                .ToList();
        }
    }
}
