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
using CrystalDecisions.CrystalReports.Engine;
using Examination_System.Models;
using Examination_System.Reports;
using Newtonsoft.Json.Linq;

namespace Examination_System.Controllers
{
    public class ExamController : ApiController
    {
        private DBEntities db = new DBEntities();

        [HttpGet]
        [Route("api/exam/getExams")]
        public IHttpActionResult GetExams()
        {
            var exams = db.Exams.Select(e => new { e.ID, e.Title, e.Duration, e.CreationDateTime });
            return Ok(exams);
        }

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

            var exam = db.Exams.Where(e=>e.ID == id).Select(e=> new { e.ID, e.Duration, e.CreationDateTime, e.Title, e.TFQuestionsNumber, e.MCQQuestionsNumber });
            bool solved = false;

            if (exam == null)
            {
                return NotFound();
            }

            //if user is instructor or if student has already solved this exam before, then show exam as solved exam
            if (userTypeID == (int)UserType.Instructor ||
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

        //DownLoad a Report for all Questions and Answers for a student in specific Exam
        [HttpPost]
        [Route("api/Student/AnswerStudent")]
        public HttpResponseMessage Export_get_student_answers(Object Info)
        {
            var info = JObject.Parse(Info.ToString());
            int ExamID = int.Parse(info.SelectToken("ExamID").ToString());
            int StudentID = int.Parse(info.SelectToken("StudentID").ToString());
            var Report1 = db.get_student_answers(ExamID, StudentID).ToList();
            if (Report1.Count == 0)
            {
                var Message = string.Format("Report Failed ");
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.NotFound, Message);
                return res;
            }
            else
            {
                CrystalReportget_student_answers obj = new CrystalReportget_student_answers();
                ReportDocument rd = new ReportDocument();
                string date = DateTime.Now.ToString();
                obj.SetDataSource(Report1.Select(qs => new { Question = qs.Question ?? "No Value", Answer = qs.Answer ?? "No Value", Right_Answer = qs.Right_Answer ?? "No Value" }));

                string path = info.SelectToken("Location").ToString() + "Student_Answers_" + DateTime.Now.ToString("HH_mm_ss") + ".pdf";
                //Trace.WriteLine(path);
                obj.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                var Message = string.Format("Report DownLoaded ");
                var res = Request.CreateResponse(HttpStatusCode.OK, Message);
                return res;
            }
        }
    }

    public class StudentExamViewModel
    {
        public int ExamID { get; set; }
        public int StudentID { get; set; }
    }

}