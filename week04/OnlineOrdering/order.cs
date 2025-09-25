 using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double TotalPrice()
    {
        double productTotal = 0;
        foreach (Product p in _products)
        {
            productTotal += p.TotalCost();
        }

        double shipping = _customer.GetAddress().IsInUSA() ? 5.0 : 35.0;
        return productTotal + shipping;
    }

    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in _products)
        {
            label += $"{p.GetName()} (ID: {p.GetProductId()})\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
