namespace ShipitSmarter.Core.Messaging.Sender;

public interface ISender {
    Task Send<TMessage>(TMessage message)
        where TMessage : IMessageContract<TMessage>;
}
