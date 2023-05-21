
namespace Domain.Common
{
    public interface IAggregateRoot<T> where T : class
    {
        T Id { get; }
    }
}
