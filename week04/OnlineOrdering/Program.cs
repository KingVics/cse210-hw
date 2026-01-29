using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        
        // Customer info and address setter
        Address address = new Address("1931 N Broadway, WA 98201", "Everett", "Washington", "United States");
        Customer customer = new Customer("John Doe", address);

        // Instantiated products
        Product productOne = new Product(1, "Kolbs Bed Wedge Pillow", 47.54, 2);
        Product productTwo = new Product(2, "Beckham Hotel Collection Bed Pillows", 57.3, 4);
        Product productThree = new Product(3, "Dr Infrared Heater Portable Space Heater", 100.3, 2);

        // Create customer order and add product to customer record
        Order orderOne = new Order(customer);
        orderOne.AddProduct(productOne);
        orderOne.AddProduct(productTwo);
        orderOne.AddProduct(productThree);

        // Display order
        Console.WriteLine(orderOne.GetPackingLabel());
        Console.WriteLine(orderOne.GetShippingLabel());
        Console.WriteLine(orderOne.GetTotalPrice());

        
    }
}