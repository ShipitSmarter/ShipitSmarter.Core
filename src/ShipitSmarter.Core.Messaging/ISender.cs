namespace ShipitSmarter.Core.Messaging;

public interface ISender {
    Task Send<TMessage>(TMessage message)
        where TMessage : IMessageContract<TMessage>;
}
