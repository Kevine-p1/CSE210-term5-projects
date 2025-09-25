 using System;

class Program
{
    static void Main()
    {
        // ----- Order 1 -----
        Address addr1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer cust1 = new Customer("Alice Johnson", addr1);

        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Laptop", "P001", 999.99, 1));
        order1.AddProduct(new Product("Mouse", "P002", 25.50, 2));

        // ----- Order 2 -----
        Address addr2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer cust2 = new Customer("Bob Smith", addr2);

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Headphones", "P003", 89.99, 1));
        order2.AddProduct(new Product("Webcam", "P004", 59.99, 1));
        order2.AddProduct(new Product("Keyboard", "P005", 49.99, 1));

        // Display orders
        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.PackingLabel());
        Console.WriteLine(order.ShippingLabel());
        Console.WriteLine($"Total Price: ${order.TotalPrice():0.00}");
    }
}
