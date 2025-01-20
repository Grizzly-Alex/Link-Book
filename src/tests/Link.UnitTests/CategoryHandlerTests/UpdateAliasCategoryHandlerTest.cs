using AutoMapper;
using FluentAssertions;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Handlers.AliasCategoryHandlers;
using Link.Core.Interfaces;
using Moq;
using Xunit;
using Link.Core.Entities.Category;
using Link.Application.Utilities;
using Link.Core.Entities;


namespace Link.UnitTests.CategoryHandlerTests;

public class UpdateAliasCategoryHandlerTest
{
    private readonly Mock<IAliasCategoryRepository> _categoryRepositoryMock;
    private readonly IMapper _mapper;

    public UpdateAliasCategoryHandlerTest()
    {
        _categoryRepositoryMock = new();

        _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))
            .CreateMapper();
    }


    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenCategoryNotFound()
    {
        // Arrange
        var command = new UpdateAliasCategoryCommand(Guid.NewGuid(), string.Empty);

        _categoryRepositoryMock.Setup(
            x => x.Update(
                It.IsAny<AliasCategory>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var handler = new UpdateAliasCategoryHandler(
                _categoryRepositoryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CategoryErrors.NotFound);
    }


    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenCategorySuccessfullyUpdated()
    {
        // Arrange
        var command = new UpdateAliasCategoryCommand(Guid.NewGuid(), string.Empty);

        _categoryRepositoryMock.Setup(
            x => x.Update(
                It.IsAny<AliasCategory>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var handler = new UpdateAliasCategoryHandler(
                _categoryRepositoryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }
}
