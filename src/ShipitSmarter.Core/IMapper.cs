namespace ShipitSmarter.Core;

/// <summary>
/// Maps an object from <typeparamref name="TSource"/> to <typeparamref name="TDest"/>
/// </summary>
/// <typeparam name="TSource">The type of the source object</typeparam>
/// <typeparam name="TDest">The type of the destination object</typeparam>
public interface IMapper<TSource, TDest>
{
    /// <summary>
    /// Maps an object from <typeparamref name="TSource"/> to <typeparamref name="TDest"/>
    /// </summary>
    TDest From(TSource source);
}

/// <summary>
/// Maps an object from <typeparamref name="TSource"/> to <typeparamref name="TDest"/>
/// </summary>
/// <typeparam name="TSource">The type of the source object</typeparam>
/// <typeparam name="TDest">The type of the destination object</typeparam>
public interface IMapperAsync<TSource, TDest>
{
    /// <summary>
    /// Maps an object from <typeparamref name="TSource"/> to <typeparamref name="TDest"/>
    /// </summary>
    Task<TDest> From(TSource source);
}
