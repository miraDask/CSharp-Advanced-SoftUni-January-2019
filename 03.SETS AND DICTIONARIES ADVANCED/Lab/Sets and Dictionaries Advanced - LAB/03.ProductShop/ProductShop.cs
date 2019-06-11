using System;
using System.Collections.Generic;
using System.Linq;

public class ProductShop
{
    public static void Main()
    {
        // shop => product -> price
        var shops = new Dictionary<string, Dictionary<string, double>>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "Revision")
            {
                break;
            }

            string[] productsData = input.Split(", ");

            string shop = productsData[0];
            string product = productsData[1];
            double price = double.Parse(productsData[2]);

            if (!shops.ContainsKey(shop))
            {
                shops.Add(shop, new Dictionary<string, double>());
            }

            if (!shops[shop].ContainsKey(product))
            {
                shops[shop].Add(product, 0);
            }
            
                shops[shop][product] = price;
            

        }

        shops = shops.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value); 

        foreach (var shopKvp in shops)
        {
            Console.WriteLine($"{shopKvp.Key}->");

            var products = shopKvp.Value;

            foreach (var productKvp in products)
            {

                Console.WriteLine($"Product: {productKvp.Key}, Price: {productKvp.Value}");
            }
        }
    }
}

