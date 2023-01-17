namespace ShipitSmarter.Core;

/// <summary>
/// A use case with no result 
/// </summary>
/// <typeparam name="TIn">The input for the use case</typeparam>
public interface IUseCase<in TIn>
{
    Task Handle(TIn input);
}

/// <summary>
/// A use case with a result
/// </summary>
/// <typeparam name="TIn">The input for the use case</typeparam>
/// <typeparam name="TOut">The output for the use case</typeparam>
public interface IUseCase<in TIn, TOut>
{
    Task<TOut> Handle(TIn input);
}