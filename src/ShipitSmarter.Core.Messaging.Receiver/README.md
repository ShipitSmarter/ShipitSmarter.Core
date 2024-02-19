# ShipitSmarter.Core.Messaging.Receiver

Defines interfaces and implementations for receiving messages.

## `IMessageHandler`

The client will require an implementation of the `IMessageHandler`. The recommended way of implementing this interface is a switch case statement based on the `Message.Subject`:

```csharp
public class MessageHandler : IMessageHandler
{
    public MessageHandler(
        // Inject handlers and other dependencies
    )

    public Task Handle(Message message) {
        switch (message.Subject) {
            case MyMessage.Subject:
                var myMessage = MyMessage.Deserialize(message);
                await myMessageHandler.Handle(myMessage);
            case MyOtherMessage.Subject:
                var myOtherMessage = MyOtherMessage.Deserialize(message);
                await myOtherMessageHandler.Handle(myOtherMessage);
            ...
        }
    }
}
```

## `GoogleSubscriberClient`

The subscriber client is implemented as a `BackgroundService`. You have to register it together with an implementation of `IMessageHandler`, `TMessageHandler`.

```csharp
services.AddGoogleSubscriberClient<TMessageHandler>("project-id", "subscription-id");
```
