using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Address address1 = new Address("123 Main St", "New York", "NY", "USA");
            Customer customer1 = new Customer("John Doe", address1);

            Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
            Customer customer2 = new Customer("Jane Smith", address2);

            Order order1 = new Order(customer1);
            order1.AddProduct(new Product("Laptop", "P1001", 999.99, 1));
            order1.AddProduct(new Product("Mouse", "P1002", 25.50, 2));

            Order order2 = new Order(customer2);
            order2.AddProduct(new Product("Smartphone", "P2001", 599.99, 1));
            order2.AddProduct(new Product("Headphones", "P2002", 79.99, 1));
            order2.AddProduct(new Product("Charger", "P2003", 19.99, 3));

            List<Order> orders = new List<Order> { order1, order2 };

            foreach (Order order in orders)
            {
                Console.WriteLine(order.GetPackingLabel());
                Console.WriteLine(order.GetShippingLabel());
                Console.WriteLine($"Total Cost: ${order.GetTotalCost():F2}");
                Console.WriteLine("----------------------------------------");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
