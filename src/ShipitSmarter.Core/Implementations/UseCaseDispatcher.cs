namespace ShipitSmarter.Core.Implementations;

#pragma warning disable CS1591
public class UseCaseDispatcher : IUseCaseDispatcher
{
    private readonly IValidationService _validationService;

    public UseCaseDispatcher(IValidationService validationService)
    {
        _validationService = validationService;
    }

    public async Task<TOut> Handle<TIn, TOut>(IUseCase<TIn, TOut> useCase, TIn input)
    {
        await _validationService.Validate(input);
        return await useCase.Handle(input);
    }

    public async Task Handle<TIn>(IUseCase<TIn> useCase, TIn input)
    {
        await _validationService.Validate(input);
        await useCase.Handle(input);
    }
}
#pragma warning restore CS1591