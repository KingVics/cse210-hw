public class Product
{
    private string _name;
    private double _price;
    private int _quantity;
    private int _productId;

    public Product(int productId, string name, double price, int quantity)
    {
        _productId = productId;
        _name = name;
        _price = price;
        _quantity = quantity;
    }

    public int GetTotalPrice()
    {
        return (int)(_price * _quantity);
    }


    public string GetProductName()
    {
        return _name;
    }

    public int GetProductId()
    {
        return _productId;
    }
}