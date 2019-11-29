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
    public class StudentController : ApiController
    {
        private DBEntities db = new DBEntities();

        // GET: api/Student/5
        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = db.Students.Where(s => s.ID == id).Select(s => new { s.ID, s.Name, s.Username, s.Password, s.Photo }).SingleOrDefault();
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
    }
}