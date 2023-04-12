using System.Runtime.Serialization;

namespace CartingService.DomainModelLayer;

[Serializable]
public class CartNotFoundException : Exception
{
    public CartNotFoundException() : base("Cart not found")
    {
    }

    public CartNotFoundException(string? message) : base(message)
    {
    }

    public CartNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CartNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}