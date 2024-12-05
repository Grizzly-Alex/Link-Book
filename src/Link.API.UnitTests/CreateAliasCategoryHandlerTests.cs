using AutoMapper;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Handlers.AliasCategoryHandlers;
using Link.Application.Responses;
using Link.Core.Entities;
using Link.Core.Interfaces;
using Moq;
using Xunit;

namespace Link.API.UnitTests;

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
        var command = new CreateAliasCategoryCommand("usertest", "social network");

        var handler = new CreateAliasCategoryHandler(
            _categoryRepositoryMock.Object,
            _categoryQueryMock.Object,
            _mapperMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        //result.IsFailure.Should().BeTrue();


    }
}
