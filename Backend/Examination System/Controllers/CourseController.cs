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
    public class CourseController : ApiController
    {
        private DBEntities db = new DBEntities();

        // GET: api/Cours
        public IHttpActionResult GetCourses()
        {
            var c = db.Courses.Select(cc => new { cc.ID, cc.Name, cc.Description, deptname = cc.Department.Name, intructorName = cc.Instructor.Name });
            return Ok(c);
        }

        // GET: api/Cours/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult GetCours(int id)
        {
            Course cours = db.Courses.Find(id);
            if (cours == null)
            {
                return BadRequest();
            }

            return Ok(cours);
        }
        [Route("api/GetDepartmentCourses/{id}")]
        public IHttpActionResult GetDepartmentCourses(int id)
        {
            Department dept = db.Departments.FirstOrDefault(c => c.ID == id);
            if (dept == null)
            {
                return BadRequest();
            }
            return Ok(new { deptName = dept.Name, course_names = dept.Courses.Select(c => c.Name) });
        }
        [Route("api/GetInstructorCourses/{id}")]
        public IHttpActionResult GetINstructorCourses(int id)
        {
            Instructor inst = db.Instructors.FirstOrDefault(c => c.ID == id);
            if (inst == null)
            {
                return NotFound();
            }
            return Ok(new { instructorName = inst.Name, course_names = inst.Courses.Select(c => c.Name) });
        }
        [Route("api/GetStudentCourses/{id}")]
        public IHttpActionResult GetStudentCourses(int id)//???
        {
            Student st = db.Students.FirstOrDefault(s => s.ID == id);
            if (st == null)
            {
                return BadRequest();
            }
            return Ok(new { st.Name, courses_name = st.Courses_Students.Select(c => c.Cours.Name) });
        }
        [Route("api/GetStudentCourses/{id}")]
        public IHttpActionResult GetStudentCoursesGrade(int id)//???
        {
            Student st = db.Students.FirstOrDefault(s => s.ID == id);
            if (st == null)
            {
                return BadRequest();
            }
            return Ok(new { st.Name, courses_name = st.Courses_Students.Select(c => c.Grade) });
        }
        // PUT: api/Cours/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult Edit([FromUri]int id, [FromBody] Course cours)
        {
            Course cs = db.Courses.Find(id);
            cs.Name = cours.Name;
            cs.InstructorID = cours.InstructorID;
            cs.DepartmentID = cours.DepartmentID;
            cs.Description = cours.Description;
            try
            {
                db.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch
            {
                return BadRequest();
            }
        }

        // POST: api/Cours
        [ResponseType(typeof(Course))]
        [HttpPost]
        public IHttpActionResult Add(Course cours)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Courses.Add(cours);
            db.SaveChanges();

            return CreatedAtRoute("Addedd Successfully", new { id = cours.ID }, cours);
        }

        // DELETE: api/Cours/5
        [ResponseType(typeof(Course))]
        public IHttpActionResult Delete(int id)
        {
            Course cours = db.Courses.Find(id);
            if (cours == null)
            {
                return NotFound();
            }

            db.delete_Courses(id);

            return Ok(cours);
        }

        [ResponseType(typeof(Course))]
        [HttpPost]
        [Route("api/joincourse")]
        public IHttpActionResult JoinCourse(Courses_Students cs)
        {
            try
            {
                db.Courses_Students.Add(cs);
                db.SaveChanges();
                return Ok(cs);
            }
            catch
            {
                return BadRequest();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursExists(int id)
        {
            return db.Courses.Count(e => e.ID == id) > 0;
        }
    }
}
