using ProductManager.Interfaces;
using ProductManager.Models;
using ProductManager.Repositories;
using ProductManager.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        ProductService _productService = new ProductService(new ProductRepository());

        try
        {
            Login();

            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("==== PRODUCT MANAGEMENT ====");
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. Show Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Update Product");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                         AddProduct(_productService);
                        break;

                    case 2:
                        ShowProducts(_productService);
                        break;

                    case 3:
                        DeleteProduct(_productService);
                        break;
                    case 4:
                        UpdateProduct(_productService);
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        ShowMessage("Invalid Option!", false);
                        Pause();
                        break;
                }
            } while (choice != 0);
        }
        catch (Exception ex)
        {
            ShowMessage("\n" + ex.Message, false);
            Pause();
        }
    }

    static void Login()
    {
        try
        {
            const string correctUser = "admin";
            const string correctPass = "1234";

            while (true)
            {
                Console.Clear();
                Console.Write("Enter Username: ");
                string user = Console.ReadLine();

                Console.Write("Enter Password: ");
                string pass = Console.ReadLine();

                if (user == correctUser && pass == correctPass)
                {
                    ShowMessage("\nLogin Successful!", true);
                    Pause();
                    break;
                }
                else
                {
                    ShowMessage("\nWrong username or password!", false);
                    Pause();
                }
            }
        }
        catch (Exception ex)
        {
            ShowMessage("\n" + ex.Message, false);
            Pause();
        }
    }
    static void AddProduct(ProductService productService)
    {
        try
        {
            Console.Write("\nEnter Product ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Product Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter Available Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            Product p = new Product()
            {
                ProductId = id,
                ProductName = name,
                ProductPrice = price,
                AvailableQuantity = qty
            };

            string result= productService.AddProduct(p);
            ShowMessage(result, true);
            Pause();
        }
        catch (Exception ex)
        {
            ShowMessage("\n" + ex.Message, false);
            Pause();
        }
    }

    static void UpdateProduct(ProductService productService)
    {
        try
        {
            var products = productService.GetProducts();

            if (products.Count() == 0)
            {
                ShowMessage("No products found!", false);
            }
            else
            {
               
                Console.Write("\nEnter Product ID: ");
                int id = Convert.ToInt32(Console.ReadLine());

                var product = productService.GetProductById(id);
                if (product == null)
                {
                    ShowMessage($"Product with ID: {id} not found!", false);
                }
                else
                {
                    Console.Write("Enter Product New Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Product New Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter New Available Quantity: ");
                    int qty = int.Parse(Console.ReadLine());

                    Product p = new Product()
                    {
                        ProductId = id,
                        ProductName = name,
                        ProductPrice = price,
                        AvailableQuantity = qty
                    };

                    string result = productService.UpdateProduct(p);
                    ShowMessage(result, true);
                }
            }
            Pause();
        }
        catch (Exception ex)
        {
            ShowMessage("\n" + ex.Message, false);
            Pause();
        }
    }

    static void ShowProducts(ProductService productService)
    {
        try
        {
            Console.WriteLine("\n==== PRODUCT LIST ====");

            var products = productService.GetProducts();

            if (products.Count() == 0)
            {
                ShowMessage("No products found!", false);
            }
            else
            {
                Console.WriteLine("\nProductID | Product Name | Product Price | Available Qty.");
                foreach (var item in products)
                {
                    Console.WriteLine($"\n{item.ProductId} | {item.ProductName} | {item.ProductPrice} | {item.AvailableQuantity}");
                }
            }

            Pause();
        }
        catch (Exception ex)
        {
            ShowMessage("\n" + ex.Message, false);
            Pause();
        }
    }

    static void DeleteProduct(ProductService productService)
    {
        try
        {
            ShowProducts(productService);

            var products = productService.GetProducts();
            if (products.Count() == 0) return;

            Console.Write("\nEnter Product ID to Remove: ");
            int id = int.Parse(Console.ReadLine());

            string status = productService.DeleteProductById(id);

            ShowMessage(status, true);

            Pause();
        }

        catch (Exception ex)
        {
            ShowMessage("\n" + ex.Message, false);
            Pause();
        }
    }
    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ShowMessage(string message, bool status)
    {
        Console.ForegroundColor = status ? ConsoleColor.Green : ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}