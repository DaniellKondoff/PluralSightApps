using Logic.Dtos;
using Logic.Interfaces;
using Logic.Students;
using Logic.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Logic.AppServices
{
    public class GetListQuery: IQuery<List<StudentDto>>
    {
        public string EnrolledIn { get; }
        public int? NumberOfCourses { get; }

        public GetListQuery(string enrooledIn, int? numberOfCourses)
        {
            this.EnrolledIn = enrooledIn;
            this.NumberOfCourses = numberOfCourses;
        }

        public class GetListQueryHandler : IQueryHandler<GetListQuery, List<StudentDto>>
        {
            private readonly UnitOfWork _unitOfWork;
            public GetListQueryHandler(UnitOfWork unitOfWork)
            {
                this._unitOfWork = unitOfWork;
            }

            public List<StudentDto> Handle(GetListQuery query)
            {
                var repository = new StudentRepository(_unitOfWork);
                IReadOnlyList<Student> students = repository.GetList(query.EnrolledIn, query.NumberOfCourses);
                List<StudentDto> dtos = students.Select(x => ConvertToDto(x)).ToList();

                return dtos;
            }

            private StudentDto ConvertToDto(Student student)
            {
                return new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Email = student.Email,
                    Course1 = student.FirstEnrollment?.Course?.Name,
                    Course1Grade = student.FirstEnrollment?.Grade.ToString(),
                    Course1Credits = student.FirstEnrollment?.Course?.Credits,
                    Course2 = student.SecondEnrollment?.Course?.Name,
                    Course2Grade = student.SecondEnrollment?.Grade.ToString(),
                    Course2Credits = student.SecondEnrollment?.Course?.Credits,
                };
            }
        }
    }
}
