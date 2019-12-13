using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using CrystalDecisions.CrystalReports.Engine;
using Examination_System.Models;
using Examination_System.Reports;
using Newtonsoft.Json.Linq;

namespace Examination_System.Controllers
{
    public class StudentController : ApiController
    {
        private DBEntities db = new DBEntities();

        // GET: api/Student
        [HttpGet]
        public IHttpActionResult GetCount()
        {
            int Students = db.Students.Count();
            if (Students == 0)
                return NotFound();
            else
                return Ok(Students);
        }


        // GET: api/Student/5
        [HttpGet]
        [Route("api/Student/{id}")]
        public IHttpActionResult GetStudent(int? id)
        {
            var student = db.Students.Where(s => s.ID == id).Select(s => new { s.ID, s.Name, s.Username, s.Password, s.Photo, deptName = s.Department.Name, courses = s.Courses_Students.Select(c => new { c.Cours.ID, c.Cours.Name, c.Grade }) }).SingleOrDefault();
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        [Route("api/student/login")]
        public IHttpActionResult Login(Student student)
        {
            var stu = db.Students.Where(s => s.Username == student.Username && s.Password == student.Password).SingleOrDefault();

            if (stu == null)
                return NotFound();
            
            return Ok(stu.ID);
        }

        [HttpPost]
        [Route("api/student/update")]
        public IHttpActionResult Update(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("api/student/add")]
        public IHttpActionResult Add(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();

            return Created("", new { id = student.ID });
        }

        [HttpGet]
        [Route("test/test")]
        public IHttpActionResult test()
        {
            try
            {


                //HttpPostedFile image = HttpContext.Current.Request.Files[0];
                //Utility.SaveImage(image, "Teachers");

                var x = Int32.Parse(Request.Headers.GetValues("userID").FirstOrDefault());
                var y = Request.Headers.GetValues("userTypeID");
                return Ok(new { x,y});
            }catch(Exception e)
            {
                Console.WriteLine(e);
                return Unauthorized();
            }
        }




        //return all students for each Dept
        [HttpGet]
        public IHttpActionResult GetDepartmentStudents(int? id)
        {
            var students = db.get_Students_by_departmentid(id);
            if (students == null)
                return NotFound();
            else
                return Ok(students);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }

        // get all students info in specific department
        [HttpGet]
        [Route("api/Student/StudentsInfo/{id}")]
        public IHttpActionResult getStudent_info_by_DeptID(int? id)
        {
            var Report1 = db.get_student_info_by_departmentid(id).ToList();
            if (Report1 == null)
                return NotFound();
            else
                return Ok(Report1);
        }


        //DownLoad a Report for all students info in specific department
        [HttpPost]
        [Route("api/Student/StudentsExport/{id}")]
        public HttpResponseMessage ExportStudent_info_by_DeptID(int? id, Object Location)
        {
            var Report1 = db.get_student_info_by_departmentid(id).ToList();
            if (Report1.Count == 0)
            {
                var Message = string.Format("Report Failed ");
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.NotFound, Message);
                return res;
            }
            else
            {
                CrystalReportStudent_Info_by_DeptID obj = new CrystalReportStudent_Info_by_DeptID();
                ReportDocument rd = new ReportDocument();
                string date = DateTime.Now.ToString();
                obj.SetDataSource(Report1);
                var loc = JObject.Parse(Location.ToString());
                //Trace.WriteLine(loc.SelectToken("Location"));
                string path = loc.SelectToken("Location").ToString() + "Students_Info_" + DateTime.Now.ToString("HH_mm_ss") + ".pdf";
                //Trace.WriteLine(path);
                obj.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                var Message = string.Format("Report DownLoaded ");
                var res = Request.CreateResponse(HttpStatusCode.OK, Message);
                return res;
            }
        }



        // get all Grades for specific Student
        [HttpGet]
        [Route("api/Student/StudentsGrade/{id}")]
        public IHttpActionResult get_courses_students_by_StudentID(int? id)
        {
            var Report1 = db.get_courses_students_by_StudentID(id).ToList();
            if (Report1 == null)
                return NotFound();
            else
                return Ok(Report1);
        }



        //DownLoad a Report for all Grades  for specific student
        [HttpPost]
        [Route("api/Student/GradesExport/{id}")]
        public HttpResponseMessage Exportget_courses_students_by_StudentID(int? id, Object Location)
        {
            var Report1 = db.get_courses_students_by_StudentID(id).ToList();
            if (Report1.Count == 0)
            {
                var Message = string.Format("Report Failed ");
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.NotFound, Message);
                return res;
            }
            else
            {
                CrystalReportget_courses_students_by_StudentID obj = new CrystalReportget_courses_students_by_StudentID();
                ReportDocument rd = new ReportDocument();
                string date = DateTime.Now.ToString();
                obj.SetDataSource(Report1.Select(g => new { Name = g.Name ?? "No Value", Grade = g.Grade ?? 0 }));
                var loc = JObject.Parse(Location.ToString());
                //Trace.WriteLine(loc.SelectToken("Location"));
                string path = loc.SelectToken("Location").ToString() + "Grades_Info_" + DateTime.Now.ToString("HH_mm_ss") + ".pdf";
                //Trace.WriteLine(path);
                obj.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                var Message = string.Format("Report DownLoaded ");
                var res = Request.CreateResponse(HttpStatusCode.OK, Message);
                return res;
            }
        }





        // get all Cources and Num of Student in each cource for specific instractor
        [HttpGet]
        [Route("api/Student/ListCources/{id}")]
        public IHttpActionResult get_courses_students_number_by_instructorid(int? id)
        {
            var Report1 = db.get_courses_students_number_by_instructorid(id).ToList();
            if (Report1 == null)
                return NotFound();
            else
                return Ok(Report1);
        }




        //DownLoad a Report for all Cources and Num of Student in each cource for specific instractor
        [HttpPost]
        [Route("api/Student/ListCources/{id}")]
        public HttpResponseMessage Export_get_courses_students_number_by_instructorid(int? id, Object Location)
        {
            var Report1 = db.get_courses_students_number_by_instructorid(id).ToList();
            if (Report1.Count == 0)
            {
                var Message = string.Format("Report Failed ");
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.NotFound, Message);
                return res;
            }
            else
            {
                CrystalReportget_courses_students_number_by_instructorid obj = new CrystalReportget_courses_students_number_by_instructorid();
                ReportDocument rd = new ReportDocument();
                string date = DateTime.Now.ToString();
                obj.SetDataSource(Report1.Select(c => new { Name = c.Name ?? "No Value", Number_of_Student = c.Number_of_Student ?? 0 }));
                var loc = JObject.Parse(Location.ToString());
                //Trace.WriteLine(loc.SelectToken("Location"));
                string path = loc.SelectToken("Location").ToString() + "List_Cources_" + DateTime.Now.ToString("HH_mm_ss") + ".pdf";
                //Trace.WriteLine(path);
                obj.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                var Message = string.Format("Report DownLoaded ");
                var res = Request.CreateResponse(HttpStatusCode.OK, Message);
                return res;
            }
        }




        // get all Topics in specific cource
        [HttpGet]
        [Route("api/Student/ListTopics/{id}")]
        public IHttpActionResult get_topics_by_courseid(int? id)
        {
            var Report1 = db.get_topics_by_courseid(id).ToList();
            if (Report1 == null)
                return NotFound();
            else
                return Ok(Report1);
        }



        //DownLoad a Report for all Topics in specific cource
        [HttpPost]
        [Route("api/Student/ListTopics/{id}")]
        public HttpResponseMessage Export_get_topics_by_courseid(int? id, Object Location)
        {
            var Report1 = db.get_topics_by_courseid(id).ToList();
            if (Report1.Count == 0)
            {
                var Message = string.Format("Report Failed ");
                HttpResponseMessage res = Request.CreateResponse(HttpStatusCode.NotFound, Message);
                return res;
            }
            else
            {
                CrystalReportget_topics_by_courseid obj = new CrystalReportget_topics_by_courseid();
                ReportDocument rd = new ReportDocument();
                string date = DateTime.Now.ToString();
                obj.SetDataSource(Report1.Select(t => new { ID = t.ID, Name = t.Name ?? "No Value" }));
                var loc = JObject.Parse(Location.ToString());
                //Trace.WriteLine(loc.SelectToken("Location"));
                string path = loc.SelectToken("Location").ToString() + "List_Topics_" + DateTime.Now.ToString("HH_mm_ss") + ".pdf";
                //Trace.WriteLine(path);
                obj.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);
                var Message = string.Format("Report DownLoaded ");
                var res = Request.CreateResponse(HttpStatusCode.OK, Message);
                return res;
            }
        }


        // get all Questions in specific Exam
        [HttpGet]
        [Route("api/Student/ListQues/{id}")]
        public IHttpActionResult get_questions_by_ExamID(int? id)
        {
            var Report1 = db.get_questions_by_ExamID(id).ToList();
            if (Report1 == null)
                return NotFound();
            else
                return Ok(Report1);
        }


        //DownLoad a Report for all Questions in specific Exam
        [HttpPost]
        [Route("api/Student/ListQues/{id}")]
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

       
    }
}