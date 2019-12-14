using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Examination_System.Models;

namespace Examination_System.Controllers
{
    public class ExamController : ApiController
    {
        private DBEntities db = new DBEntities();

        [HttpGet]
        [Route("api/exam/getCourseExams/{courseID}")]
        public IHttpActionResult GetCourseExams(int courseID)
        {
            var exams = db.Exams.Where(e => e.CourseID == courseID).Select(e => new { e.ID, e.Title, e.Duration, e.CreationDateTime });
            return Ok(exams);
        }

        [HttpGet]
        [Route("api/exam/correct/{id}")]
        public IHttpActionResult CorrectExam(int id)
        {
            int? studentID;

            try
            {
                studentID = Int32.Parse(Request.Headers.GetValues("userID").FirstOrDefault());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return Unauthorized();
            }

            db.correct_exam(id, studentID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("api/exam/studentAnswers")]
        public IHttpActionResult GetStudentAnswers(StudentExamViewModel studentExam)
        {
            var studentAnswers = db.get_student_answers(studentExam.ExamID, studentExam.StudentID);
            return Ok(studentAnswers);
        }


        [HttpGet]
        [Route("api/exam/getExam/{id}")]
        public IHttpActionResult GetExam(int id)
        {
            int? userTypeID;
            int? userID;

            try
            {
                userTypeID = Int32.Parse(Request.Headers.GetValues("userTypeID").FirstOrDefault());
                userID = Int32.Parse(Request.Headers.GetValues("userID").FirstOrDefault());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Unauthorized();
            }

            var exam = db.Exams.Where(e=>e.ID == id).Select(e=> new { e.ID, e.Questions, e.Duration, e.CreationDateTime, e.Title, e.TFQuestionsNumber, e.MCQQuestionsNumber });
            bool solved = false;

            if (exam == null)
            {
                return NotFound();
            }

            // if user is instructor or if student has already solved this exam before, then show exam as solved exam 
            if(userTypeID == (int) UserType.Instructor || 
                db.Students_Exams_Answers.FirstOrDefault(sea => sea.ExamID == id && sea.StudentID == userID) != null)
            {
                solved = true;
            }

            return Ok(new { solved, exam });
        }

        [HttpPost]
        [Route("api/exam/add")]
        public IHttpActionResult Add(Exam exam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Exams.Add(exam);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("api/exam/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return NotFound();
            }

            db.delete_exams(id);

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class StudentExamViewModel
    {
        public int ExamID { get; set; }
        public int StudentID { get; set; }
    }

}