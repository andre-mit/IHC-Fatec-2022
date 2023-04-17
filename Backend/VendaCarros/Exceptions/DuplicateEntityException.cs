using System.Runtime.CompilerServices;

namespace VendaCarros.Exceptions;

public class DuplicateEntityException<T> : Exception
{
    public DuplicateEntityException()
    {
        InnerException?.Data.Add(nameof(T), "Duplicated");
    }

    public DuplicateEntityException(string message) : base(message)
    {
    }

    public DuplicateEntityException(string message, Exception innerException) : base(message, innerException)
    {
        
    }
}