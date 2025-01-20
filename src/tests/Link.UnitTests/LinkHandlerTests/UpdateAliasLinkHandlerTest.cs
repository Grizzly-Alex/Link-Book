using AutoMapper;
using FluentAssertions;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Handlers.AliasLinkHandlers;
using Link.Application.Utilities;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Entities.Link;
using Link.Core.Interfaces;
using Moq;
using Xunit;


namespace Link.UnitTests.LinkHandlerTests;

public class UpdateAliasLinkHandlerTest
{
    private readonly Mock<IAliasLinkRepository> _linkRepositoryMock;
    private readonly Mock<IAliasCategoryQuery<Guid?>> _queryMock;
    private readonly IMapper _mapper;

    public UpdateAliasLinkHandlerTest()
    {
        _linkRepositoryMock = new();
        _queryMock = new();

        _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))
            .CreateMapper();
    }


    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenCategoryNotFound()
    {
        // Arrange
        var command = new UpdateAliasLinkCommand() 
        {
            Id = Guid.NewGuid(),
            AliasUrl = string.Empty,
            OriginalUrl = string.Empty,
            Favorite = true,
            CategoryId = Guid.NewGuid(),
        };

        _queryMock.Setup(
            x => x.Contains(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        _linkRepositoryMock.Setup(
            x => x.Update(
                It.IsAny<AliasLink>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var handler = new UpdateAliasLinkHandler(
                _linkRepositoryMock.Object,
                _queryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CategoryErrors.NotFound);
    }


    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenLinkNotFound()
    {
        // Arrange
        var command = new UpdateAliasLinkCommand()
        {
            Id = Guid.NewGuid(),
            AliasUrl = string.Empty,
            OriginalUrl = string.Empty,
            Favorite = true,
            CategoryId = Guid.NewGuid(),
        };

        _queryMock.Setup(
            x => x.Contains(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        _linkRepositoryMock.Setup(
            x => x.Update(
                It.IsAny<AliasLink>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var handler = new UpdateAliasLinkHandler(
                _linkRepositoryMock.Object,
                _queryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(LinkErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenLinkSuccessfullyUpdated()
    {
        // Arrange
        var command = new UpdateAliasLinkCommand()
        {
            Id = Guid.NewGuid(),
            AliasUrl = string.Empty,
            OriginalUrl = string.Empty,
            Favorite = true,
            CategoryId = Guid.NewGuid(),
        };

        _queryMock.Setup(
            x => x.Contains(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        _linkRepositoryMock.Setup(
            x => x.Update(
                It.IsAny<AliasLink>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var handler = new UpdateAliasLinkHandler(
                _linkRepositoryMock.Object,
                _queryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }
}
