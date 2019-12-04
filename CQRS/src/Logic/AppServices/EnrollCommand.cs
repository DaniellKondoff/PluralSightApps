using CSharpFunctionalExtensions;
using Logic.Interfaces;
using Logic.Students;
using Logic.Utils;
using System;

namespace Logic.AppServices
{
    public class EnrollCommand : ICommand
    {
        public long Id { get; }
        public string Course { get; }
        public string Grade { get; }

        public EnrollCommand(long id, string course, string grade)
        {
            this.Id = id;
            this.Course = course;
            this.Grade = grade;
        }

        public class EnrollComandHandler : ICommandHandler<EnrollCommand>
        {
            private readonly UnitOfWork _unitOfWork;
            public EnrollComandHandler(UnitOfWork unitOfWork)
            {
                this._unitOfWork = unitOfWork;
            }

            public Result Handle(EnrollCommand command)
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

                student.Enroll(course, grade);

                _unitOfWork.Commit();

                return Result.Ok();
            }
        }
    }
}
