using System;
using Logic.Dtos;
using CSharpFunctionalExtensions;
using Logic.Students;
using Logic.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/students")]
    public sealed class StudentController : BaseController
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly StudentRepository _studentRepository;
        private readonly CourseRepository _courseRepository;
        private readonly Messages _messages;

        public StudentController(UnitOfWork unitOfWork, Messages messages)
        {
            _unitOfWork = unitOfWork;
            _studentRepository = new StudentRepository(unitOfWork);
            _courseRepository = new CourseRepository(unitOfWork);
            _messages = messages;
        }

        [HttpGet]
        public IActionResult GetList(string enrolled, int? number)
        {
            var list = _messages.Dispatch(new GetListQuery(enrolled, number));

            return Ok(list);
        }

       

        [HttpPost]
        public IActionResult Register([FromBody] RegisterStudentDto dto)
        {
            var command = new RegisterCommand(dto.Name, dto.Email);

            Result result = _messages.Dispatch(command);

            return FromResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Unregister(long id)
        {
            var command = new UnregisterCommand(id);

            Result result = _messages.Dispatch(command);

            return FromResult(result);
        }

        [HttpPost("{id}/enrollments")]
        public IActionResult Enroll(long id, [FromBody] StudentEnrollmentDto dto)
        {
            Student student = _studentRepository.GetById(id);
            if (student == null)
                return Error($"No student found for Id {id}");

            Course course = _courseRepository.GetByName(dto.Course);
            if (course == null)
                return Error($"Course is incorrect: {dto.Course}");

            bool success = Enum.TryParse(dto.Grade, out Grade grade);
            if (!success)
                return Error($"Grade is incorrect: {dto.Grade}");

            student.Enroll(course, grade);

            _unitOfWork.Commit();

            return Ok();
        }

        [HttpPut("{id}/enrollments/{enrollmentNumber}")]
        public IActionResult Transfer(long id, int enrollmentNumber, [FromBody] StudentTransferDto dto)
        {
            Student student = _studentRepository.GetById(id);
            if (student == null)
                return Error($"No student found for Id {id}");

            Course course = _courseRepository.GetByName(dto.Course);
            if (course == null)
                return Error($"Course is incorrect: {dto.Course}");

            bool success = Enum.TryParse(dto.Grade, out Grade grade);
            if (!success)
                return Error($"Grade is incorrect: {dto.Grade}");

            Enrollment enrollment = student.GetEnrollment(enrollmentNumber);
            if (enrollment == null)
                return Error($"No Enrollment: {enrollmentNumber}");

            enrollment.Update(course, grade);

            _unitOfWork.Commit();

            return Ok();
        }

        public IActionResult Disenroll(long id, int enrollmentNumber, [FromBody] StudentDisenrollmentDto dto)
        {
            Student student = _studentRepository.GetById(id);
            if (student == null)
                return Error($"No student found for Id {id}");

            if (string.IsNullOrWhiteSpace(dto.Comment))
                return Error("Disenrollment comment is required");

            Enrollment enrollment = student.GetEnrollment(enrollmentNumber);
            if (enrollment == null)
                return Error($"No Enrollment: {enrollmentNumber}");

            student.RemoveEnrollment(enrollment, dto.Comment);

            _unitOfWork.Commit();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditPersonalInfo(long id, [FromBody] StudentPersonalInfo dto)
        {
            var command = new EditPersonalInfoCommand(id, dto.Name, dto.Email);

            Result result = _messages.Dispatch(command);

            return result.IsSuccess ? Ok() : Error(result.Error);
        }
    }
}
