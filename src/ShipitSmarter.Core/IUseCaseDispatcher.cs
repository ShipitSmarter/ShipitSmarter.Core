namespace ShipitSmarter.Core;

/// <summary>
/// The dispatcher ensures the input is of a use case is validated before calling <see cref="IUseCase{TIn}.Handle"/> or
/// <see cref="IUseCase{TIn, TOut}.Handle"/> of use case implementation.
/// </summary>
public interface IUseCaseDispatcher
{
    /// <summary>
    /// Validate the input before sending it to the use case.
    /// </summary>
    /// <param name="useCase">The use case to handle</param>
    /// <param name="input">The input for the use case</param>
    /// <typeparam name="TIn">The type of the input</typeparam>
    /// <typeparam name="TOut">The type of the output</typeparam>
    /// <returns>The output of the use case</returns>
    Task<TOut> Handle<TIn, TOut>(IUseCase<TIn, TOut> useCase, TIn input);
    
    /// <summary>
    /// Validate the input before sending it to the use case.
    /// </summary>
    /// <param name="useCase">The use case to handle</param>
    /// <param name="input">The input for the use case</param>
    /// <typeparam name="TIn">The type of the input</typeparam>
    Task Handle<TIn>(IUseCase<TIn> useCase, TIn input);
}