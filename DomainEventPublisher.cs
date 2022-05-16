using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore.DomainEvent
{
    public interface IDomainEventPublisher
    {
        Task Publish<T>(T msg) where T : IDomainEvent;
    }
    internal class DomainEventPublisher : IDomainEventPublisher
    {
        IServiceProvider _serviceProvider;

        public DomainEventPublisher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Publish<T>(T msg) where T : IDomainEvent
        {
            var handlers = _serviceProvider.GetServices<IDomainEventHandler<T>>();
            foreach (var handler in handlers)
            {
                await handler.Handle(msg);
            }
        }
    }
}