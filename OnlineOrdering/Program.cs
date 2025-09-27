class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Order 1 ---");

        Address address1 = new Address("123 Maple St", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Smith", address1);
        Order order1 = new Order(customer1);

        Product p1_1 = new Product("Wireless Mouse", "A-101", 25.99, 1);
        Product p1_2 = new Product("Keyboard", "A-102", 49.95, 1);
        Product p1_3 = new Product("USB Hub", "B-205", 15.50, 2);
        order1.AddProduct(p1_1);
        order1.AddProduct(p1_2);
        order1.AddProduct(p1_3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():F2}\n");

        Console.WriteLine("--- Order 2 ---");

        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Mary Jones", address2);
        Order order2 = new Order(customer2);

        Product p2_1 = new Product("Laptop Stand", "C-310", 45.00, 1);
        Product p2_2 = new Product("External Hard Drive", "D-415", 89.99, 1);
        order2.AddProduct(p2_1);
        order2.AddProduct(p2_2);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():F2}");
    }
}
