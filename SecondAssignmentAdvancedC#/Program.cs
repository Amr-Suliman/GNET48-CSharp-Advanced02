using ShopMaster.OrderProcessing.Models;
using SecondAssignmentAdvancedC_.Services;

namespace SecondAssignmentAdvancedC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> catalog = new()
            {
                new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
                new Product { Id=2, Name="Phone", Category="Electronics", Price=800, Stock=25 },
                new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
                new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
                new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
                new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
                new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
                new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
                new Product { Id=9, Name="Headphones", Category="Electronics", Price=150, Stock=40 },
                new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
            };

            // Task 01 - Search Electronics
            List<Product> electronics = ProductService.SearchProducts(
            catalog,
            p => p.Category == "Electronics");

            Console.WriteLine("=== Electronics ===");

            foreach (Product product in electronics)
            {
                Console.WriteLine($"{product.Name} - ${product.Price}");
            }

            // Task 01 - Search Products Under $50

            List<Product> cheapProducts = ProductService.SearchProducts(
            catalog,
            p => p.Price < 50);

            Console.WriteLine("\n=== Products Under $50 ===");

            foreach (Product product in cheapProducts)
            {
                Console.WriteLine($"{product.Name} - ${product.Price}");
            }

            // Task 01 - Products In Stock
            List<Product> inStockProducts = ProductService.SearchProducts(
                catalog,
                p => p.Stock > 0
            );

            Console.WriteLine("\n=== Products In Stock ===");
            foreach (Product product in inStockProducts)
            {
                Console.WriteLine($"{product.Name} - Stock: {product.Stock}");
            }

            // Task 01 - Clothing Under $100
            List<Product> clothingProducts = ProductService.SearchProducts(
                catalog,
                p => p.Category == "Clothing" && p.Price < 100
            );

            Console.WriteLine("\n=== Clothing Under $100 ===");
            foreach (Product product in clothingProducts)
            {
                Console.WriteLine($"{product.Name} - ${product.Price}");
            }

            Console.WriteLine("\n=== Short Report ===");

            ProductService.PrintReport(
                catalog,
                p => Console.WriteLine($"{p.Name} - ${p.Price}")
            );

            Console.WriteLine("\n=== Detailed Report ===");

            ProductService.PrintReport(
                catalog,
                p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}")
            );

            List<string> productSummaries = ProductService.TransformProducts(
              catalog,
               p => $"{p.Name} (${p.Price})");

            Console.WriteLine("\n=== Product Summaries ===");

            foreach (string summary in productSummaries)
            {
                Console.WriteLine(summary);
            }

        }
    }
}