﻿using Link.Core.Entities;
using MediatR;

namespace Link.Application.Commands;

public interface ICommandHandler<TCommand> :  IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
