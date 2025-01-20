namespace Link.Application.Commands.AliasCategoryCommands;

public record class DeleteAliasCategoryCommand(Guid Id) : ICommand;