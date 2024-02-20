# ShipitSmarter.Core.Messaging

Defines the core objects, interfaces and implentations for handling messages.

## Define a new message

A new message should implement the `IMessageContract<TMessage>` interface, so the definition of how to serialize and deserialize the message is defined with the message itself. Implemting this interface also allows the new message to be handled by the Publisher and Subscriber packages.

This package provides a default implementation of the `IMessageContract<TMessage>`, the `JsonMessageContract<TMessage>` that will serialize the data as JSON. To create a new message using this implenation, simply extend from this class and define your data structure for the message:

```csharp
using ShipitSmarter.Core.Messaging;

public class ExampleEvent : JsonMessageContract<ExampleEvent> {
    public Guid ExampleId { get; }
    public string SomeStringProperty { get; }
    public int SomeIntProperty { get; }

    public ExampleEvent(
        Guid exampleId,
        string someStringProperty,
        int someIntProperty
    )
    {
        ExampleId = exampleId;
        SomeStringProperty = someStringProperty;
        SomeIntProperty = someIntProperty;
    }
}
```
