public class Order
{
    private List<Product> _product = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _product.Add(product);
    }


    public string GetTotalPrice()
    {
        int totalPrice = 0;
        foreach (Product product in _product)
        {
            if (_customer.IsInUSA())
            {
                totalPrice += (int)(product.GetTotalPrice() + 5.00);
            }
            else
            {
                totalPrice += (int)(product.GetTotalPrice() + 35.00);
            }
            totalPrice += product.GetTotalPrice();
        }
        return $"${totalPrice.ToString("N0")}";
    }


    public string GetPackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (Product product in _product)
        {
            packingLabel += $"Product Name: {product.GetProductName()}, Product ID: {product.GetProductId()}\n";
        }
        return packingLabel;
    }


    public string GetShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"Customer Name: {_customer.GetName()}\n";
        shippingLabel += $"Address: {_customer.GetFullAddress()}\n";
        return shippingLabel;
    }

}