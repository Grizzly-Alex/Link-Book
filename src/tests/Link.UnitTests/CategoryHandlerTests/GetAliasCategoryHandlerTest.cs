using AutoMapper;
using FluentAssertions;
using Link.Application.Handlers.AliasCategoryHandlers;
using Link.Core.Interfaces;
using Moq;
using Xunit;
using Link.Core.Entities.Category;
using Link.Application.Utilities;
using Link.Application.Queries.AliasCategoryQueries;
using System.Linq.Expressions;
using Link.Core.Entities;


namespace Link.UnitTests.CategoryHandlerTests;

public class GetAliasCategoryHandlerTest
{
    private readonly Mock<IAliasCategoryRepository> _categoryRepositoryMock;
    private readonly IMapper _mapper;

    public GetAliasCategoryHandlerTest()
    {
        _categoryRepositoryMock = new();

        _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))
            .CreateMapper();
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenUserHaveNotCategories()
    {
        // Arrange
        var query = new GetAllAliasCategoriesByUserQuery(string.Empty);

        _categoryRepositoryMock.Setup(
            x => x.GetAll(
                It.IsAny<Expression<Func<AliasCategory, bool>>>(),
                It.IsAny<Func<IQueryable<AliasCategory>, IOrderedQueryable<AliasCategory>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<AliasCategory>());

        var handler = new GetAllAliasCategoriesByUserHandler(
                _categoryRepositoryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CategoryErrors.NotFound);
    }


    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenUserHaveSomeCategories()
    {
        // Arrange
        var query = new GetAllAliasCategoriesByUserQuery(string.Empty);

        _categoryRepositoryMock.Setup(
            x => x.GetAll(
                It.IsAny<Expression<Func<AliasCategory, bool>>>(),
                It.IsAny<Func<IQueryable<AliasCategory>, IOrderedQueryable<AliasCategory>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<AliasCategory>() { new AliasCategory(string.Empty, string.Empty)});

        var handler = new GetAllAliasCategoriesByUserHandler(
                _categoryRepositoryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.IsFailure.Should().BeFalse();
        result.Error.Should().Be(Error.None);
        result.Value.Should().NotBeNull();
    }
}
