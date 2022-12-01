using System.Runtime.CompilerServices;

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
        _orderLines ?? throw ThrowHelper.UninitializedProperty();
}

public class OrderLine
{
    public OrderLine(string productName)
    {
        ProductName = productName;
    }

    public string ProductName { get; }
}

internal static class ThrowHelper
{
    public static InvalidOperationException UninitializedProperty(
        [CallerMemberName] string? propertyName = null
    )
    {
        return new InvalidOperationException(
            $"Accessing uninitialized property '{propertyName}'. Did you forget to include the relation when querying the DbContext?"
        );
    }
}
