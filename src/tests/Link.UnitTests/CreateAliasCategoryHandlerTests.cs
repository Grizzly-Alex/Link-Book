using AutoMapper;
using FluentAssertions;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Handlers.AliasCategoryHandlers;
using Link.Core.Interfaces;
using Moq;
using Xunit;
using Link.Core.Entities.Category;

namespace Link.UnitTests;

public class CreateAliasCategoryHandlerTests
{
    private readonly Mock<IAliasCategoryRepository> _categoryRepositoryMock;
    private readonly Mock<IAliasCategoryQuery<Guid?>> _categoryQueryMock;
    private readonly Mock<IMapper> _mapperMock;

    public CreateAliasCategoryHandlerTests()
    {
        _categoryRepositoryMock = new();
        _categoryQueryMock = new();
        _mapperMock = new();
    }

    [Fact]
    public async Task Handle_Should_FailureResult_WhenCategoryIsNotUniqueForUser()
    {
        // Arrange
        var command = new CreateAliasCategoryCommand("user", "social network");

        _categoryQueryMock.Setup(
            x => x.Contains(
                It.IsAny<AliasCategory>(), 
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var handler = new CreateAliasCategoryHandler(
                _categoryRepositoryMock.Object,
                _categoryQueryMock.Object,
                _mapperMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CategoryErrors.Conflict);
    }
}
