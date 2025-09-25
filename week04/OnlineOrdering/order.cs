using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double TotalPrice()
    {
        double total = 0;
        foreach (Product p in products)
        {
            total += p.TotalCost();
        }
        double shipping = customer.IsInUSA() ? 5 : 35;
        return total + shipping;
    }

    public string PackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product p in products)
        {
            sb.AppendLine($"- {p.Name} (ID: {p.ProductId})");
        }
        return sb.ToString();
    }

    public string ShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address}";
    }
}
