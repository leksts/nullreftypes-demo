namespace NullRefTypesDemo.Domain;

public class Order
{
    private readonly IEnumerable<OrderLine>? _orderLines;

    // Public contructor for creating new orders
    public Order(IEnumerable<OrderLine> orderLines) : this()
    {
        _orderLines = orderLines;
    }

    // Protected contructor for efcore
    protected Order() { }

    public IEnumerable<OrderLine> OrderLines =>
        _orderLines
        ?? throw new InvalidOperationException(
            $"Accessing uninitialized property '{nameof(OrderLines)}'"
        );
}

public class OrderLine
{
    public OrderLine(string productName)
    {
        ProductName = productName;
    }

    public string ProductName { get; }
}
