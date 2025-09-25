 using System;

class Program
{
    static void Main()
    {
        // Create addresses
        Address addr1 = new Address("123 Main St", "Boise", "ID", "USA");
        Address addr2 = new Address("45 King St", "Toronto", "ON", "Canada");

        // Create customers
        Customer cust1 = new Customer("Alice Johnson", addr1);
        Customer cust2 = new Customer("Liam Chen", addr2);

        // Create orders
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop Sleeve", "LS100", 25.99, 2));
        order1.AddProduct(new Product("Wireless Mouse", "WM200", 19.50, 1));

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Bluetooth Speaker", "BS300", 49.99, 1));
        order2.AddProduct(new Product("Travel Mug", "TM400", 12.75, 3));

        // Display results
        DisplayOrder(order1);
        Console.WriteLine(new string('-', 40));
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.PackingLabel());
        Console.WriteLine(order.ShippingLabel());
        Console.WriteLine($"Total Price: ${order.TotalPrice():0.00}");
    }
}
