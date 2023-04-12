using System.Runtime.Serialization;

namespace CartingService.DomainModelLayer;

[Serializable]
public class CartItemAlreadyAddedException : Exception
{
    public CartItemAlreadyAddedException() : base("CartItem already added")
    {
    }

    public CartItemAlreadyAddedException(string? message) : base(message)
    {
    }

    public CartItemAlreadyAddedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected CartItemAlreadyAddedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}