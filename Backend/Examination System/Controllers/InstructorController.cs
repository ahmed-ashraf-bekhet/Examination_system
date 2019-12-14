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
    public class InstructorController : ApiController
    {
        private DBEntities db = new DBEntities();

        // GET: api/Instructor
        [HttpGet]
        public IHttpActionResult GetInstructors()
        {
            var instructors = db.Instructors.Select(i => new { i.ID, i.Name, i.Photo, i.DepartmentID, deptName = i.Department.Name});
            
            return Ok(instructors);
        }


        [HttpGet]
        [Route("api/getInstructorsNumber")]
        public IHttpActionResult GetInstructorsNumber()
        {
            return Ok(db.Instructors.Count());
        }

        // GET: api/Instructor/5
        [HttpGet]
        public IHttpActionResult GetInstructor(int id)
        {
            var instructor = db.Instructors.Where(s => s.ID == id).Select(i => new { i.ID, i.Name, i.Username, i.Password, i.IsAdmin, DeptName = i.Department.Name }).SingleOrDefault();
            if (instructor == null)
                return NotFound();

            return Ok(instructor);
        }

        [Route("api/GetDepartmentInstructors/{id}")]
        public IHttpActionResult GetDepartmentTeachers(int id)
        {
            var instructors = db.Instructors.Where(i => i.DepartmentID == id).Select(i => new { i.ID, i.Name, i.DepartmentID, deptName = i.Department.Name, i.Photo });

            if (instructors == null)
            {
                return BadRequest();
            }
            return Ok(instructors);
        }

        [HttpPost]
        [Route("api/instructor/login")]
        public IHttpActionResult Login(Instructor instructor)
        {
            var ins = db.Instructors.Where(i => i.Username == instructor.Username && i.Password == instructor.Password).SingleOrDefault();

            if (ins == null)
                return NotFound();

            return Ok(new { ins.ID,ins.IsAdmin});
        }

        [HttpPost]
        [Route("api/instructor/update")]
        public IHttpActionResult Update(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(instructor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructorExists(instructor.ID))
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
        [Route("api/instructor/add")]
        public IHttpActionResult Add(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Instructors.Add(instructor);
            db.SaveChanges();

            return Created("", new { id = instructor.ID });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstructorExists(int id)
        {
            return db.Instructors.Count(e => e.ID == id) > 0;
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
    }
}