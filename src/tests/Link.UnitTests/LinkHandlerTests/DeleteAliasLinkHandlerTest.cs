using FluentAssertions;
using Link.Application.Commands.AliasLinkCommands;
using Link.Application.Handlers.AliasLinkHandlers;
using Link.Core.Entities;
using Link.Core.Entities.Link;
using Link.Core.Interfaces;
using Moq;
using Xunit;


namespace Link.UnitTests.LinkHandlerTests;

public class DeleteAliasLinkHandlerTest
{
    private readonly Mock<IAliasLinkRepository> _linkRepositoryMock;

    public DeleteAliasLinkHandlerTest()
    {
        _linkRepositoryMock = new();
    }


    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenLinkNotFound()
    {
        // Arrange
        var command = new DeleteAliasLinkCommand(Guid.NewGuid());

        _linkRepositoryMock.Setup(
            x => x.Delete(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        var handler = new DeleteAliasLinkHandler(_linkRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(LinkErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenLinkSuccessfullyRemoved()
    {
        // Arrange
        var command = new DeleteAliasLinkCommand(Guid.NewGuid());

        _linkRepositoryMock.Setup(
            x => x.Delete(
                It.IsAny<Guid>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var handler = new DeleteAliasLinkHandler(_linkRepositoryMock.Object);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }
}
