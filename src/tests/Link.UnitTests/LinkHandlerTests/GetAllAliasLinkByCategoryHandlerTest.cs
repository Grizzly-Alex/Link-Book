using AutoMapper;
using FluentAssertions;
using Link.Application.Handlers.AliasLinkHandlers;
using Link.Application.Queries.AliasLinkQueries;
using Link.Application.Utilities;
using Link.Core.Entities;
using Link.Core.Entities.Category;
using Link.Core.Entities.Link;
using Link.Core.Interfaces;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace Link.UnitTests.LinkHandlerTests;

public class GetAllAliasLinkByCategoryHandlerTest
{
    private readonly Mock<IAliasLinkRepository> _linkRepositoryMock;
    private readonly IMapper _mapper;

    public GetAllAliasLinkByCategoryHandlerTest()
    {
        _linkRepositoryMock = new();

        _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))
            .CreateMapper();
    }


    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenLinkForCategoryNotFound()
    {
        // Arrange
        var query = new GetAllAliasLinkByCategoryQuery(Guid.NewGuid());

        _linkRepositoryMock.Setup(
            x => x.GetAll(
                It.IsAny<Expression<Func<AliasLink, bool>>>(),
                It.IsAny<Func<IQueryable<AliasLink>, IOrderedQueryable<AliasLink>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<AliasLink>());

        var handler = new GetAllAliasLinkByCategoryHandler(_linkRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CategoryErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenHaveLinksForCategory()
    {
        // Arrange
        var query = new GetAllAliasLinkByCategoryQuery(Guid.NewGuid());

        _linkRepositoryMock.Setup(
            x => x.GetAll(
                It.IsAny<Expression<Func<AliasLink, bool>>>(),
                It.IsAny<Func<IQueryable<AliasLink>, IOrderedQueryable<AliasLink>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<AliasLink>()
            {
                new(){ AliasUrl = string.Empty, OriginalUrl= string.Empty, UserId = string.Empty }
            });

        var handler = new GetAllAliasLinkByCategoryHandler(_linkRepositoryMock.Object, _mapper);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
    }
}
