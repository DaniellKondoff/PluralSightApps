using CSharpFunctionalExtensions;
using Logic.Interfaces;
using Logic.Students;
using Logic.Utils;

namespace Logic.AppServices
{
    public class UnregisterCommand : ICommand
    {
        public long Id { get; }

        public UnregisterCommand(long Id)
        {
            this.Id = Id;
        }

        public class UnregisterCommandHandler : ICommandHandler<UnregisterCommand>
        {
            private readonly UnitOfWork _unitOfWork;
            public UnregisterCommandHandler(UnitOfWork unitOfWork)
            {
                this._unitOfWork = unitOfWork;
            }

            public Result Handle(UnregisterCommand command)
            {
                var repository = new StudentRepository(_unitOfWork);

                Student student = repository.GetById(command.Id);
                if (student == null)
                    return Result.Fail($"No student found for Id {command.Id}");

                repository.Delete(student);
                _unitOfWork.Commit();

                return Result.Ok();
            }
        }
    }
}
