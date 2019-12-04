using CSharpFunctionalExtensions;
using Logic.Interfaces;
using Logic.Students;
using Logic.Utils;

namespace Logic.AppServices
{
    public class DisenrollCommand : ICommand
    {
        public long Id { get; }
        public int EnrollmentNumber { get; }
        public string Comment { get; }

        public DisenrollCommand(long id, int enrollmentNumber, string comment)
        {
            this.Id = id;
            this.EnrollmentNumber = enrollmentNumber;
            this.Comment = comment;
        }

        public class DisenrollCommandHandler : ICommandHandler<DisenrollCommand>
        {
            private readonly UnitOfWork _unitOfWork;
            public DisenrollCommandHandler(UnitOfWork unitOfWork)
            {
                this._unitOfWork = unitOfWork;
            }

            public Result Handle(DisenrollCommand command)
            {
                var studentRepository = new StudentRepository(_unitOfWork);
                Student student = studentRepository.GetById(command.Id);
                if (student == null)
                    Result.Fail($"No student found for Id {command.Id}");

                if (string.IsNullOrWhiteSpace(command.Comment))
                    Result.Fail("Disenrollment comment is required");

                Enrollment enrollment = student.GetEnrollment(command.EnrollmentNumber);
                if (enrollment == null)
                    Result.Fail($"No Enrollment: {command.EnrollmentNumber}");

                student.RemoveEnrollment(enrollment, command.Comment);

                _unitOfWork.Commit();

                return Result.Ok();
            }
        }
    }
}
