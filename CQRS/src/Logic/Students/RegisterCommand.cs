using CSharpFunctionalExtensions;
using Logic.Interfaces;
using Logic.Utils;

namespace Logic.Students
{
    public sealed class RegisterCommand : ICommand
    {
        public string Name { get; }

        public string Email { get; }

        public RegisterCommand(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }
    }

    public sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly UnitOfWork _unitOfWork;
        public RegisterCommandHandler(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Result Handle(RegisterCommand command)
        {
            var student = new Student(command.Name, command.Email);

            var repository = new StudentRepository(_unitOfWork);
            repository.Save(student);

            _unitOfWork.Commit();

            return Result.Ok();
        }
    }
}
