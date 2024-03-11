# ShipitSmarter.Core.Messaging.Subscriber

Defines interfaces and implementations for receiving messages.

## `IMessageHandler`

The client will require an implementation of the `IMessageHandler`. The recommended way of implementing this interface is by creating a control flow based on the `Message.Subject`:

```csharp
public class MessageHandler : IMessageHandler
{
    public MessageHandler(
        // Inject handlers and other dependencies
    )

    public Task Handle(Message message) {
        if (MyMessage.Subject == message.Subject) {
            var myMessage = MyMessage.Deserialize(message);
            return myMessageHandler.Handle(myMessage);
        }
        if (MyOtherMessage.Subject == message.Subject) {
            var myOtherMessage = MyOtherMessage.Deserialize(message);
            return myOtherMessageHandler.Handle(myOtherMessage);
        }
        ...
    }
}
```

## `GoogleSubscriberClient`

The subscriber client is implemented as a `BackgroundService`. You have to register it together with an implementation of `IMessageHandler`, `TMessageHandler`.

```csharp
services.AddGoogleSubscriberClient<TMessageHandler>("project-id", "subscription-id");
```

### Google Pub/Sub emulator

The client builder is setup to recognize and use emulator settings when they are set. See [Testing apps locally with the emulator](https://cloud.google.com/pubsub/docs/emulator) for more information.
