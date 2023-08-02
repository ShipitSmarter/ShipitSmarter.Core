using FluentAssertions;
using Moq;
using ShipitSmarter.Core.Implementations;

namespace ShipitSmarter.Core.Tests;

public class UseCaseDispatcherTests
{
    [Fact]
    public async Task Handle_ValidatesAndCalls()
    {
        // Arrange
        var testObject = new object();
        var validationService = new Mock<IValidationService>();
        validationService.Setup(x => x.Validate(It.IsAny<object>()))
            .Verifiable();
        var useCase = new Mock<IUseCase<object, object>>();
        useCase.Setup(x => x.Handle(It.IsAny<object>()))
            .ReturnsAsync(new object());
        var dispatcher = new UseCaseDispatcher(validationService.Object);

        // Act
        await dispatcher.Handle(useCase.Object, testObject);

        // Assert
        validationService.Verify(x => x.Validate(testObject), Times.Once);
        useCase.Verify(x => x.Handle(testObject), Times.Once);
    }
    
    [Fact]
    public async Task Handle_IfValidateThrowsDoesNotCallUseCase()
    {
        // Arrange
        var testObject = new object();
        var validationService = new Mock<IValidationService>();
        validationService.Setup(x => x.Validate(It.IsAny<object>()))
            .Throws(new Exception())
            .Verifiable();
        var useCase = new Mock<IUseCase<object, object>>();
        useCase.Setup(x => x.Handle(It.IsAny<object>()))
            .ReturnsAsync(new object());
        var dispatcher = new UseCaseDispatcher(validationService.Object);

        // Act
        var act = () => dispatcher.Handle(useCase.Object, testObject);
        
        // Assert
        await act.Should().ThrowAsync<Exception>();
        validationService.Verify(x => x.Validate(testObject), Times.Once);
        useCase.Verify(x => x.Handle(testObject), Times.Never);
    }
}
