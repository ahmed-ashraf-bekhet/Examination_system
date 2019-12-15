using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json.Linq;
using Part_Of_Project.Models;
using Part_Of_Project.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Part_Of_Project.Controllers
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
            catch (Exception e)
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
                userTypeID =  Int32.Parse(Request.Headers.GetValues("userTypeID").FirstOrDefault());
                userID =  Int32.Parse(Request.Headers.GetValues("userID").FirstOrDefault());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Unauthorized();
            }

            var exam = db.Exams.Where(e => e.ID == id).Select(e => new { e.ID, e.Duration, e.CreationDateTime, e.Title, e.TFQuestionsNumber, e.MCQQuestionsNumber });
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

        [HttpGet]
        [Route("api/examquestion/{id}")]
        public IHttpActionResult GetExamQuestions(int id)
        {
            var exq = db.get_questions_Answers_by_ExamID(id);

            var updated = exq.AsEnumerable()
                .Select(x => new
                {
                    QnID = x.QID,
                    Qn = x.Question,
                    Options = new string[] {
                        x.option1,
                        x.option2,
                        x.option3,
                        x.option4
                    },
                    Options_ID = new object[] {
                        x.Answer_ID1,
                        x.Answer_ID2,
                        x.Answer_ID3,
                        x.Answer_ID4
                    },
                    QtypeId = x.TypeID
                }).ToList();

            if (updated == null)
                return NotFound();
            else
                return Ok(updated);
        }

        [HttpGet]
        [Route("api/Student/AnswerStudent/{examID}")]
        public IHttpActionResult get_Question_answer(int? examID)
        {
            var QuestionAndAns = db.get_Question_answer(examID).ToList();
            if (QuestionAndAns == null)
                return NotFound();
            else
                return Ok(QuestionAndAns);
        }

        [HttpPost]
        [Route("api/StudentAnswer")]
        public IHttpActionResult InsertStudentAnswer(Students_Exams_AnswersView sea)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.insert_Student_Exam_Answer(sea.StudentID, sea.QuetionID, sea.ExamID, sea.ANserID);

            return StatusCode(HttpStatusCode.Created);
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

        //DownLoad a Report for all Questions in specific Exam
        [HttpPost]
        [Route("api/Exam/ListQues/{id}")]
        public HttpResponseMessage Export_get_questions_by_ExamID(int? id, Object Location)
        {
            var Report1 = db.get_questions_by_ExamID(id).ToList();
            if (Report1.Count == 0)
            {
                var Message = string.Format("Report Failed ");
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.NotFound, Message);
                return res;
            }
            else
            {
                CrystalReportget_questions_by_ExamID obj = new CrystalReportget_questions_by_ExamID();
                ReportDocument rd = new ReportDocument();
                string date = DateTime.Now.ToString();
                obj.SetDataSource(Report1.Select(q => new { Body = q.Body ?? "No Value" }));
                var loc = JObject.Parse(Location.ToString());
                //Trace.WriteLine(loc.SelectToken("Location"));
                string path = loc.SelectToken("Location").ToString() + "Exam_Questions_" + DateTime.Now.ToString("HH_mm_ss") + ".pdf";
                //Trace.WriteLine(path);
                obj.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                var Message = string.Format("Report DownLoaded ");
                var res = Request.CreateResponse(HttpStatusCode.OK, Message);
                return res;
            }
        }

        //DownLoad a Report for all Questions and Answers for a student in specific Exam
        [HttpPost]
        [Route("api/Exam/AnswerStudent")]
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
    public class Students_Exams_AnswersView
    {
        public int StudentID { get; set; }
        public int QuetionID { get; set; }
        public int ExamID { get; set; }
        public int ANserID { get; set; }
    }
}

