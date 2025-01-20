using FluentAssertions;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Handlers.AliasCategoryHandlers;
using Link.Application.Handlers.AliasLinkHandlers;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Interfaces;
using Moq;
using Xunit;


namespace Link.UnitTests.CategoryHandlerTests;

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
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CategoryErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenCategorySuccessfullyRemoved()
    {
        // Arrange
        var command = new DeleteAliasCategoryCommand(Guid.NewGuid());

        _categoryRepositoryMock.Setup(
            x => x.Delete(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var handler = new DeleteAliasCategoryHandler(_categoryRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }
}
