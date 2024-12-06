﻿using AutoMapper;
using FluentAssertions;
using Link.Application.Commands.AliasCategoryCommands;
using Link.Application.Handlers.AliasCategoryHandlers;
using Link.Core.Interfaces;
using Moq;
using Xunit;
using Link.Core.Entities.Category;
using Link.Application.Utilities;

namespace Link.UnitTests;

public class CreateAliasCategoryHandlerTests
{
    private readonly Mock<IAliasCategoryRepository> _categoryRepositoryMock;
    private readonly Mock<IAliasCategoryQuery<Guid?>> _categoryQueryMock;
    private readonly IMapper _mapper;

    public CreateAliasCategoryHandlerTests()
    {
        _categoryRepositoryMock = new();
        _categoryQueryMock = new();

        _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()))
            .CreateMapper(); 
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenCategoryIsNotUniqueForUser()
    {
        // Arrange
        var command = new CreateAliasCategoryCommand("userId", "social network");

        _categoryQueryMock.Setup(
            x => x.Contains(
                It.IsAny<AliasCategory>(), 
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        var handler = new CreateAliasCategoryHandler(
                _categoryRepositoryMock.Object,
                _categoryQueryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(CategoryErrors.Conflict);
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccessResult_WhenCategoryIsUniqueForUser()
    {
        // Arrange
        var command = new CreateAliasCategoryCommand("userId", "social network");

        _categoryQueryMock.Setup(
            x => x.Contains(
                It.IsAny<AliasCategory>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);

        _categoryRepositoryMock.Setup(
            x => x.Create(
                It.IsAny<AliasCategory>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new AliasCategory(command.UserId, command.Name));

        var handler = new CreateAliasCategoryHandler(
                _categoryRepositoryMock.Object,
                _categoryQueryMock.Object,
                _mapper);

        // Act
        var result = await handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
    }
}
