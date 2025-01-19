using FluentAssertions;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Handlers.AliasCategoryHandlers;
using Link.Core.Entities.Category;
using Link.Core.Interfaces;
using Moq;
using Xunit;


namespace Link.UnitTests;

public class DeleteAliasCategoryHandlerTest
{
    private readonly Mock<IAliasCategoryRepository> _categoryRepositoryMock;

    public DeleteAliasCategoryHandlerTest()
    {
        _categoryRepositoryMock = new();
    }


    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenCategoryNotFound()
    {
        // Arrange
        var command = new DeleteAliasCategoryCommand(Guid.NewGuid());

        _categoryRepositoryMock.Setup(
            x => x.Delete(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var handler = new DeleteAliasCategoryHandler(_categoryRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CategoryErrors.NotFound);
    }
}
