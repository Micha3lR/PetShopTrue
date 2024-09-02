using PetShopTrue;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;


namespace PetShopTrue
{
    internal class Program
    {
        private static UILogic _uiLogic;

        static void Main(string[] args)
        {
            var productLogic = new ProductLogic();
            _uiLogic = new UILogic(productLogic);

            string userInput;
            do
            {
                Console.Clear();
                Console.WriteLine("Press '1' to add a dog leash");
                Console.WriteLine("Press '2' to add cat food");
                Console.WriteLine("Press '3' to retrieve a product");
                Console.WriteLine("Press '4' to view in-stock products");
                Console.WriteLine("Press '5' to get total price");
                Console.WriteLine("Type 'exit' to quit");
                userInput = Console.ReadLine()!.ToLower();

                switch (userInput)
                {
                    case "1":
                        _uiLogic.AddDogLeash();
                        break;
                    case "2":
                        _uiLogic.AddCatFood();
                        break;
                    case "3":
                        _uiLogic.RetrieveProduct();
                        break;
                    case "4":
                        _uiLogic.ViewInStockProducts();
                        break;
                    case "5":
                        _uiLogic.ShowTotalPrice();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }

                Console.Write("Press enter to continue...");
                Console.ReadLine();
            } while (userInput != "exit");
        }
    }
}
