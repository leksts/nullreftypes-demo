namespace NullRefTypesDemo.Domain;

public class Order
{
    // Public contructor for creating new orders
    public Order(IEnumerable<OrderLine> orderLines) : this()
    {
        OrderLines = orderLines;
    }

    // Protected contructor for efcore
    protected Order() { }

    public IEnumerable<OrderLine> OrderLines { get; }
}

public class OrderLine
{
    public OrderLine(string productName)
    {
        ProductName = productName;
    }

    public string ProductName { get; }
}
