namespace ShipitSmarter.Core.Messaging;

public interface IPublisher {
    Task Publish<TMessage>(TMessage message)
        where TMessage : IMessageContract<TMessage>;
}
