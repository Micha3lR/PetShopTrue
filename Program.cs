using PetShopTrue;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;


namespace PetShopTrue
{
    internal class Program
    {
        private static ProductLogic productLogic = new ProductLogic();

        static void Main(string[] args)
        {
            string userInput = string.Empty;

            while (userInput.ToLower() != "exit")
            {
                Console.Clear();
                Console.WriteLine("Press '1' to add a dog leash");
                Console.WriteLine("Press '2' to add a cat food");
                Console.WriteLine("Press '3' to retrieve a product");
                Console.WriteLine("Press '4' to view in stock products");
                Console.WriteLine("Type 'exit' to quit");
                userInput = Console.ReadLine()!.ToLower();
                switch (userInput)
                {
                    case "1":
                        var dogLeash = new DogLeash();

                        Console.Write("Enter the name of the dogleash: ");
                        dogLeash.Name = Console.ReadLine()!;

                        Console.Write("Enter a description of the dogleash: ");
                        dogLeash.Description = Console.ReadLine()!;

                        Console.Write("Enter the length of the dogleash: ");
                        dogLeash.LengthInches = int.Parse(Console.ReadLine()!);

                        Console.Write("Enter the material of the dogleash: ");
                        dogLeash.Material = Console.ReadLine()!;

                        Console.Write("Enter the quantity of the product: ");
                        dogLeash.Quantity = int.Parse(Console.ReadLine()!);

                        Console.WriteLine($"You have chosen: ");
                        Console.WriteLine($"Name: {dogLeash.Name}");
                        Console.WriteLine($"Description: {dogLeash.Description}");
                        Console.WriteLine($"Length: {dogLeash.LengthInches} in.");
                        Console.WriteLine($"Material: {dogLeash.Material}");
                        Console.WriteLine($"Quantity: {dogLeash.Quantity}");

                        productLogic.AddProduct(dogLeash);

                        Console.WriteLine("Added new dogleash...");
                        Console.WriteLine();
                        Console.Write("Press enter to continue...");
                        Console.ReadLine();

                        continue;

                    case "2":
                        var catFood = new CatFood();

                        Console.Write("Enter the name of the cat food: ");
                        catFood.Name = Console.ReadLine()!;

                        Console.Write("Enter a description of the cat food: ");
                        catFood.Description = Console.ReadLine()!;

                        Console.Write("Enter the weight of the cat food: ");
                        catFood.WeightPounds = double.Parse(Console.ReadLine()!);

                        Console.Write("Is this kitten food?: ");
                        catFood.IsKittenFood = bool.Parse(Console.ReadLine()!.ToLower());

                        Console.Write("Enter the quantity of the product: ");
                        catFood.Quantity = int.Parse(Console.ReadLine()!);

                        Console.WriteLine($"You have chosen: ");
                        Console.WriteLine($"Name: {catFood.Name}");
                        Console.WriteLine($"Description: {catFood.Description}");
                        Console.WriteLine($"Weight: {catFood.WeightPounds} lbs.");
                        Console.WriteLine($"Is Kitten Food: {catFood.IsKittenFood}");
                        Console.WriteLine($"Quantity: {catFood.Quantity} units");

                        productLogic.AddProduct(catFood);

                        Console.WriteLine("Added new cat food...");
                        Console.WriteLine();
                        Console.Write("Press enter to continue...");
                        Console.ReadLine();

                        continue;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Press '1' to retrieve a dog leash");
                        Console.WriteLine("Press '2' to retrieve cat food");
                        string userChoice = Console.ReadLine()!;

                        switch (userChoice)
                        {
                            case "1":
                                Console.Write("Enter the name of the product: ");
                                string dogLeashSearch = Console.ReadLine()!;
                                var retrievedDogLeash = productLogic.GetDogLeashByName(dogLeashSearch);

                                if(retrievedDogLeash != null)
                                {
                                    Console.WriteLine($"Name: {retrievedDogLeash.Name}");
                                    Console.WriteLine($"Description: {retrievedDogLeash.Description}");
                                    Console.WriteLine($"Length: {retrievedDogLeash.LengthInches} in.");
                                    Console.WriteLine($"Material: {retrievedDogLeash.Material}");
                                    Console.WriteLine($"Quantity: {retrievedDogLeash.Quantity}");
                                }
                                else
                                {
                                    Console.WriteLine("No product found.");
                                }
                                break;

                            case "2":
                                Console.Write("Enter the name of the product: ");
                                string catFoodSearch = Console.ReadLine()!;
                                var retrievedCatFood = productLogic.GetCatFoodByName(catFoodSearch);

                                if (retrievedCatFood != null)
                                {
                                    Console.WriteLine($"Name: {retrievedCatFood.Name}");
                                    Console.WriteLine($"Description: {retrievedCatFood.Description}");
                                    Console.WriteLine($"Weight: {retrievedCatFood.WeightPounds} lbs.");
                                    Console.WriteLine($"Is Kitten Food: {retrievedCatFood.IsKittenFood}");
                                    Console.WriteLine($"Quantity: {retrievedCatFood.Quantity} units");
                                }
                                else
                                {
                                    Console.WriteLine("No product found.");
                                }
                                break;
                            default:
                                Console.WriteLine("Invalid input.");
                                break;
                        }
                        break;

                    case "4":
                        List<string> inStockProducts = productLogic.GetOnlyInStockProducts();

                        if (inStockProducts.Any())
                        {
                            Console.WriteLine("In Stock Products: ");
                            foreach (var productName in inStockProducts)
                            {
                                Product product = productLogic
                                    .GetAllProducts()
                                    .FirstOrDefault(p => p.Name == productName)!;
                                if (product != null)
                                {
                                    Console.WriteLine($"Name: {product.Name}");
                                    Console.WriteLine($"Price: {product.Price}");
                                    Console.WriteLine($"Description: {product.Description}");
                                    Console.WriteLine($"Quantity: {product.Quantity}");
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("No products in stock.");
                                }
                            }
                        }
                        break;

                    case "exit":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }

                Console.Write("Press enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
