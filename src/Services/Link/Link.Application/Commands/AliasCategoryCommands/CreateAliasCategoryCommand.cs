using Link.Application.Responses;

namespace Link.Application.Commands.AliasCategoryCommands;

public record class CreateAliasCategoryCommand(string UserId, string Name) : ICommand<AliasCategoryResponse>;