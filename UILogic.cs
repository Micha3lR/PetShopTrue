using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopTrue
{
    /// <summary>
    /// Handles user interactions related to user interface
    /// </summary>
    internal class UILogic
    {
        private readonly IProductLogic _productLogic;

        public UILogic(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }

        private static string Prompt(string message)
        {
            Console.Write(message);
            return Console.ReadLine()!;
        }

        public void AddDogLeash()
        {
            var dogLeash = new DogLeash
            {
                Name = Prompt("Enter the name of the dog leash: "),
                Description = Prompt("Enter a description of the dog leash: "),
                LengthInches = int.Parse(Prompt("Enter the length of the dog leash: ")),
                Material = Prompt("Enter the material of the dog leash: "),
                Quantity = int.Parse(Prompt("Enter the quantity of the product: ")),
                Price = decimal.Parse(Prompt("Enter the price of the dog leash: "))
            };

            _productLogic.AddProduct(dogLeash);
            Console.WriteLine("Added new dog leash.");
        }

        public void AddCatFood()
        {
            var catFood = new CatFood
            {
                Name = Prompt("Enter the name of the cat food: "),
                Description = Prompt("Enter a description of the cat food: "),
                WeightPounds = double.Parse(Prompt("Enter the weight of the cat food: ")),
                IsKittenFood = bool.Parse(Prompt("Is this kitten food? (true/false): ")),
                Quantity = int.Parse(Prompt("Enter the quantity of the product: ")),
                Price = decimal.Parse(Prompt("Enter the price of the product: "))
            };

            _productLogic.AddProduct(catFood);
            Console.WriteLine("Added new cat food.");
        }

        public void RetrieveProduct()
        {
            Console.WriteLine("Press '1' to retrieve a dog leash");
            Console.WriteLine("Press '2' to retrieve cat food");
            string userChoice = Console.ReadLine()!;

            if(userChoice == "1")
            {
                var name = Prompt("Enter the name of the dog leash: ");
                var dogLeash = _productLogic
                    .GetDogLeashByName(name);
                PrintProductDetails(dogLeash);
            }
            else if(userChoice == "2")
            {
                var name = Prompt("Enter the name of the cat food: ");
                var catFood = _productLogic
                    .GetCatFoodByName(name);
                PrintProductDetails(catFood);
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }

        public void ViewInStockProducts()
        {
            var inStockProducts = _productLogic.GetOnlyInStockProducts();
            Console.WriteLine("In Stock Products: ");
            foreach(var name in inStockProducts)
            {
                var product = _productLogic
                    .GetAllProducts()
                    .FirstOrDefault(p => p.Name == name);
                PrintProductDetails(product!);
            }
        }

        private static void PrintProductDetails(Product product)
        {
            if (product != null)
            {
                if (product is DogLeash dogLeash)
                {
                    Console.WriteLine($"Name: {dogLeash.Name}");
                    Console.WriteLine($"Description: {dogLeash.Description}");
                    Console.WriteLine($"Quantity: {dogLeash.Quantity}");
                    Console.WriteLine($"Material: {dogLeash.Material}");
                    Console.WriteLine($"Length: {dogLeash.LengthInches} in.");
                    Console.WriteLine($"Price: {dogLeash.Price:C}");
                    Console.WriteLine();
                }
                else if (product is CatFood catFood)
                {
                    Console.WriteLine($"Name: {catFood.Name}");
                    Console.WriteLine($"Description: {catFood.Description}");
                    Console.WriteLine($"Quantity: {catFood.Quantity}");
                    Console.WriteLine($"Weight: {catFood.WeightPounds} lbs.");
                    Console.WriteLine($"Kitten Food: {catFood.IsKittenFood}");
                    Console.WriteLine($"Price: {catFood.Price:C}");
                    Console.WriteLine();
                }
                
            }
            else
            {
                Console.WriteLine("No product found.");
            }
        }

        public void ShowTotalPrice()
        {
            var totalPrice = _productLogic
                .GetTotalPriceOfInventory();
            Console.WriteLine($"Total Price of Inventory: {totalPrice:C}");
        }
    }
}
