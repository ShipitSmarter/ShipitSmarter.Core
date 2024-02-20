namespace ShipitSmarter.Core.Messaging.Receiver;

public interface IMessageHandler {
    Task Handle(Message message);
}
