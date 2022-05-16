using System.Threading.Tasks;

namespace AspNetCore.DomainEvent
{
    public interface IDomainEventHandler<T> where T : IDomainEvent
    {
        Task Handle(T msg);
    }
}