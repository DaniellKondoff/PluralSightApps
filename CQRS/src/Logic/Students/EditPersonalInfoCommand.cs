using CSharpFunctionalExtensions;
using Logic.Interfaces;
using Logic.Utils;

namespace Logic.Students
{
    public class EditPersonalInfoCommand : ICommand
    {
        public long Id { get; }
        public string Name { get; }
        public string Email { get; }

        public EditPersonalInfoCommand(long id, string name, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }
    }

    public sealed class EditPersonalInfoCommandHandler : ICommandHandler<EditPersonalInfoCommand>
    {
        private readonly SessionFactory _sessionFactory;
        public EditPersonalInfoCommandHandler(SessionFactory sessionFactory)
        {
            this._sessionFactory = sessionFactory;
        }

        public Result Handle(EditPersonalInfoCommand command)
        {
            var unitOfWork = new UnitOfWork(_sessionFactory);
            var repository = new StudentRepository(unitOfWork);

            Student student = repository.GetById(command.Id);

            if (student == null)
                return Result.Fail(($"No student found for Id {command.Id}"));

            student.Name = command.Name;
            student.Email = command.Email;

            unitOfWork.Commit();

            return Result.Ok();
        }
    }
}
