using CSharpFunctionalExtensions;
using Logic.Interfaces;
using Logic.Students;
using Logic.Utils;
using System;

namespace Logic.AppServices
{
    public class TransferEnrollmentCommand : ICommand
    {
        public long Id { get; }
        public int EnrollmentNumber { get; }

        public string Course { get; }
        public string Grade { get; }

        public TransferEnrollmentCommand(long id, int enrollmentNumber, string course, string grade)
        {
            this.Id = id;
            this.EnrollmentNumber = enrollmentNumber;
            this.Course = course;
            this.Grade = grade;
        }

        public class TransferEnrollmentCommandHandler : ICommandHandler<TransferEnrollmentCommand>
        {
            private readonly UnitOfWork _unitOfWork;
            public TransferEnrollmentCommandHandler(UnitOfWork unitOfWork)
            {
                this._unitOfWork = unitOfWork;
            }

            public Result Handle(TransferEnrollmentCommand command)
            {
                var studentRepository = new StudentRepository(_unitOfWork);
                Student student = studentRepository.GetById(command.Id);
                if (student == null)
                    Result.Fail($"No student found for Id {command.Id}");

                var courseRepository = new CourseRepository(_unitOfWork);
                Course course = courseRepository.GetByName(command.Course);
                if (course == null)
                    Result.Fail($"Course is incorrect: {command.Course}");

                bool success = Enum.TryParse(command.Grade, out Grade grade);
                if (!success)
                    Result.Fail($"Grade is incorrect: {command.Grade}");

                Enrollment enrollment = student.GetEnrollment(command.EnrollmentNumber);
                if (enrollment == null)
                    Result.Fail($"No Enrollment: {command.EnrollmentNumber}");

                enrollment.Update(course, grade);

                _unitOfWork.Commit();

                return Result.Ok();
            }
        }
    }
}
