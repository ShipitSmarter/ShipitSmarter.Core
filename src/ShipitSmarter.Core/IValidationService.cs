namespace ShipitSmarter.Core;

/// <summary>
/// Service that validates the input.
/// </summary>
public interface IValidationService
{
    /// <summary>
    /// Validate the input
    /// </summary>
    /// <param name="input">The object to be validated</param>
    /// <typeparam name="T">The type of the input</typeparam>
    /// <returns>Completed task if valid, otherwise throws ValidationException</returns>
    Task Validate<T>(T input);
}