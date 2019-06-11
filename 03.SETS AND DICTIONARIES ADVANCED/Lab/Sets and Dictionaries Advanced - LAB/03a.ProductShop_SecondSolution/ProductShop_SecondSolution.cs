using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public Product(string name)
    {
        this.Name = name;
        this.Price = 0;
    }

    public string Name { get; set; }
    public double Price { get; set; }

}
class ProductShop_SecondSolution
{
    static void Main(string[] args)
    {
        Dictionary<string, List<Product>> shops = new Dictionary<string, List<Product>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Revision")
            {
                break;
            }

            string[] productsData = input.Split(new char[] { ',', ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            string shop = productsData[0];
            string product = productsData[1];
            double price = double.Parse(productsData[2]);

            if (!shops.ContainsKey(shop))
            {
                shops.Add(shop, new List<Product>());
            }

            if (!shops[shop].Any(p => p.Name == product))
            {
                shops[shop].Add(new Product(product));
            }

            var currentProduct = shops[shop].Find(p => p.Name == product);
            currentProduct.Price = price;

        }

        foreach (var shopKvp in shops.OrderBy(s => s.Key))
        {
            Console.WriteLine($"{shopKvp.Key}->");

            var products = shopKvp.Value;

            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Name}, Price: {product.Price:f1}");
            }
        }
    }
}

