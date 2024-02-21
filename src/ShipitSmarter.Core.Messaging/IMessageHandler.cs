namespace ShipitSmarter.Core.Messaging;

public interface IMessageHandler
{
    Task Handle(Message message);
}
