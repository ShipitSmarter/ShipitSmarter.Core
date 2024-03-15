using Google.Api.Gax;
using Google.Cloud.PubSub.V1;
using ShipitSmarter.Core.Messaging;
using ShipitSmarter.Core.Messaging.Subscriber;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="GoogleSubscriberClient"/> and <typeparamref name="TMessageHandler"/>.
    /// </summary>
    /// <param name="projectId">The id of the Google project for the PubSub topic.</param>
    /// <param name="topicId">The id of the PubSub subscription.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddGoogleSubscriberClient<TMessageHandler>(
        this IServiceCollection services,
        string projectId,
        string subscriptionId
    )
        where TMessageHandler : class, IMessageHandler
    {
        var subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);

        services.AddSubscriberClient(builder => {
            builder.SubscriptionName = subscriptionName;
            builder.EmulatorDetection = EmulatorDetection.EmulatorOrProduction;
        });
        services.AddScoped<IMessageHandler, TMessageHandler>();
        services.AddHostedService<GoogleSubscriberClient>();

        return services;
    }
}
