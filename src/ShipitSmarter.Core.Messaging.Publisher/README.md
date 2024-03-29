# ShipitSmarter.Core.Messaging.Sender

Defines interfaces and implementations for sending messages.

## `IPublisher`

```csharp
public class MyService {
    private readonly IPublisher _publisher;

    public MyService(IPublisher publisher) {
        _publisher = publisher;
    }

    public async Task DoSomething() {
        var msg = new MyMessage();
        await _publisher.Publish(msg);
    }
}
```

## `GooglePublisherClient`

Register the client:

```csharp
services.AddGooglePublisherClient("project-id", "topic-id");
```

You'll also need to have an implementation of `ICorrelator` registered.

Use the client as `IPublisher`.
