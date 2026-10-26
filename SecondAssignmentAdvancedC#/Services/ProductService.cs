using ShopMaster.OrderProcessing.Models;

namespace SecondAssignmentAdvancedC_.Services
{
    public static class ProductService
    {
        public static List<Product> SearchProducts(
        List<Product> products,
        Func<Product, bool> filter)
        {
            List<Product> result = new();

            if (products is not null && products.Count > 0 && filter is not null)
            {
                foreach (Product product in products)
                {
                    if (filter(product))
                    {
                        result.Add(product);
                    }
                }
            }

            return result;
        }
        public static void PrintReport(
        List<Product> products,Action<Product> printer)
        {
            if (products is not null && printer is not null)
            {
                foreach (Product product in products)
                {
                    printer(product);
                }
            }
        }

        public static List<string> TransformProducts(
        List<Product> products,Func<Product, string> transformer)
        {
            List<string> result = new();

            if (products is not null && transformer is not null)
            {
                foreach (Product product in products)
                {
                    string text = transformer(product);
                    result.Add(text);
                }
            }

            return result;
        }
    }
}