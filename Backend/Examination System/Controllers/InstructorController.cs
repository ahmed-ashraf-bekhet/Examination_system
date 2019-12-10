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
    public class InstructorController : ApiController
    {
        private ExaminationSystemDBEntities db = new ExaminationSystemDBEntities();

        // GET: api/Instructor
        [HttpGet]
        public IHttpActionResult GetInstructors()
        {
            var instructors = db.Instructors.Select(i => new { i.ID, i.Name, i.Photo, i.DepartmentID, deptName = i.Department.Name});
            
            return Ok(instructors);
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
    }
}