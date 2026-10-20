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
    }
}