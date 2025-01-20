namespace Link.Application.Commands.AliasCategoryCommands;

public record class UpdateAliasCategoryCommand(Guid Id, string NewName) : ICommand;