using CSharpFunctionalExtensions;

namespace Logic.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
