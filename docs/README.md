# AspNetCore.DomainEvent

## inject domain event
```
builder.Services.AddDomainEvent();
```
## create domain event
```
public class TestEvent : IDomainEvent
{
    public string Name { get; private set; }

    public TestEvent(string name)
    {
        Name = name;
    }
}
```
## create domain event handlers
```
public class TestEventHandler1 : IDomainEventHandler<TestEvent>
{
    public async Task Handle(TestEvent msg)
    {
        Console.WriteLine("this is TestEventHandler1 " + msg.Name);
    }
}

public class TestEventHandler2 : IDomainEventHandler<TestEvent>
{
    public async Task Handle(TestEvent msg)
    {
        Console.WriteLine("this is TestEventHandler2 " + msg.Name);
    }
}
```
## publish domain event
```
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    IDomainEventPublisher _publisher;

    public TestController(IDomainEventPublisher publisher)
    {
        _publisher = publisher;
    }

    [HttpGet]
    public async Task<string> Get()
    {
        await _publisher.Publish(new TestEvent { Name = "123" });
        return "hello domain event";
    }
}
```
