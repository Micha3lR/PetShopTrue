using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetShopTrue
{
    internal class ProductLogic : IProductLogic
    {
        private List<Product> _products;
        private Dictionary<string, DogLeash> _dogLeashes;
        private Dictionary<string, CatFood> _catFoods;

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

            _dogLeashes = new Dictionary<string, DogLeash>();
            _catFoods = new Dictionary<string, CatFood>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);

            switch (product)
            {
                case DogLeash dogLeash:
                    _dogLeashes[dogLeash.Name] = dogLeash;
                    break;

                case CatFood catFood:
                    _catFoods[catFood.Name] = catFood;
                    break;
            }
        }

        public List<Product> GetAllProducts() => _products;

        public DogLeash GetDogLeashByName(string name) => _dogLeashes
            .TryGetValue(name, out var dogLeash) 
            ? dogLeash : null!;

        public CatFood GetCatFoodByName(string name) => _catFoods
            .TryGetValue(name, out var catFood) 
            ? catFood : null!;

        public List<string> GetOnlyInStockProducts() => _products
            .InStock()
            .Select(p => p.Name)
            .ToList();

        public decimal GetTotalPriceOfInventory() => _products
            .InStock()
            .Sum(p => p.Price * p.Quantity);
    }

    static class ListExtensions
    {
        public static List<T> InStock<T>(this List<T> list) where T : Product => list
                .Where(p => p.Quantity > 0)
                .ToList();
    }
}