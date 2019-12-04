using CSharpFunctionalExtensions;
using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Decorators
{
    public class DatabaseRetryDecorator<TCommand> : ICommandHandler<TCommand>  where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> handler;
        public DatabaseRetryDecorator(ICommandHandler<TCommand> handler)
        {
            this.handler = handler;
        }

        public Result Handle(TCommand command)
        {
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    Result result = handler.Handle(command);
                    return result;
                }
                catch (Exception ex)
                {
                    if(i >=3 || !IsDatabaseException(ex))
                        throw;
                }
            }

            throw new InvalidOperationException("Should not ever get here");
        }


        private bool IsDatabaseException(Exception exception)
        {
            string message = exception.InnerException?.Message;

            if (message == null)
                return false;

            return message.Contains("The connection is broken and recovery is not possible")
                || message.Contains("error occured while establishing a connection");
        }
    }
}
