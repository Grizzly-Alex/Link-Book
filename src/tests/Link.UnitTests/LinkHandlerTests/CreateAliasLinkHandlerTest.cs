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

public class CreateAliasLinkHandlerTest
{
    private readonly Mock<IAliasLinkRepository> _linkRepositoryMock;
    private readonly Mock<IAliasCategoryQuery<Guid?>> _categoryQueryMock;
    private readonly IMapper _mapper;

    public CreateAliasLinkHandlerTest()
    {
        _linkRepositoryMock = new();
        _categoryQueryMock = new();

        _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))
            .CreateMapper();
    }

    
    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenCategoryNotExist()
    {
        // Arrange
        var command = new CreateAliasLinkCommand()
        {
            UserId = string.Empty,
            AliasUrl = string.Empty,
            OriginalUrl = string.Empty,
            Favorite = true,
            CategoryId = Guid.NewGuid()
        };

        _categoryQueryMock.Setup(
            x => x.Contains(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var handler = new CreateAliasLinkHandler(
                _linkRepositoryMock.Object,
                _categoryQueryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CategoryErrors.NotFound);
    }
    
    
    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenLinkSuccessfullyСreated()
    {
        // Arrange
        var command = new CreateAliasLinkCommand()
        {
            UserId = string.Empty,
            AliasUrl = string.Empty,
            OriginalUrl = string.Empty,
            Favorite = true,
            CategoryId = Guid.NewGuid()
        };

        _categoryQueryMock.Setup(
            x => x.Contains(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        _linkRepositoryMock.Setup(
            x => x.Create(
                It.IsAny<AliasLink>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AliasLink()
            {
                    Id = Guid.NewGuid(),
                    UserId = string.Empty,
                    AliasUrl = string.Empty,
                    OriginalUrl = string.Empty
            });

        var handler = new CreateAliasLinkHandler(
                _linkRepositoryMock.Object,
                _categoryQueryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
        result.Value.Should().NotBeNull();
    }
}