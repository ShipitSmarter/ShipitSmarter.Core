# ShipitSmarter.Core.Messaging.Sender

Defines interfaces and implementations for sending messages.

## `ISender`

```csharp
public class MyService {
    private readonly ISender _sender;

    public MyService(ISender sender) {
        _sender = sender;
    }

    public async Task DoSomething() {
        var msg = new MyMessage();
        await _sender.Send(msg);
    }
}
```

## `GooglePublisherClient`

Register the client:

```csharp
services.AddGooglePublisherClient("project-id", "topic-id");
```

You'll also need to have an implementation of `ICorrelator` registered.

Use the client as `ISender`.
