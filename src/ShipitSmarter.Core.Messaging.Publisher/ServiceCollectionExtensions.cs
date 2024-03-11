using Google.Api.Gax;
using Google.Cloud.PubSub.V1;
using ShipitSmarter.Core.Messaging;
using ShipitSmarter.Core.Messaging.Publisher;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers a <see cref="GooglePublisherClient"/> as <see cref="IPublisher"/>.
    /// </summary>
    /// <param name="projectId">The id of the Google project for the PubSub topic.</param>
    /// <param name="topicId">The id of the PubSub topic.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddGooglePublisherClient(
        this IServiceCollection services,
        string projectId,
        string topicId
    )
    {
        var topicName = TopicName.FromProjectTopic(projectId, topicId);

        services.AddPublisherClient(builder => {
            builder.TopicName = topicName;
            builder.EmulatorDetection = EmulatorDetection.EmulatorOrProduction;
        });
        services.AddScoped<IPublisher,GooglePublisherClient>();

        return services;
    }
}
