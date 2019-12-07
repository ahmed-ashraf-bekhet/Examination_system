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
        private ExaminationSystemDBEntities db = new ExaminationSystemDBEntities();

        // GET: api/Course
        public IHttpActionResult GetCourses()
        {
            var c = db.Courses.Select(cc => new { cc.ID, cc.Name, cc.Description, cc.DepartmentID, deptname = cc.Department.Name, cc.Photo });
            return Ok(c);
        }

        // GET: api/Course/5
        [ResponseType(typeof(Cours))]
        public IHttpActionResult GetCourse(int id)
        {
            var course = db.Courses.Where(c=>c.ID == id).Select(c=>new { c.ID, c.Name, c.Description, deptname = c.Department.Name, c.Photo,
                instructorID = c.Instructor.ID, instructorName = c.Instructor.Name, instructorPhoto = c.Instructor.Photo, instructorBio = c.Instructor.Bio });
            if (course == null)
            {
                return BadRequest();
            }

            return Ok(course);
        }

        [Route("api/GetDepartmentCourses/{id}")]
        public IHttpActionResult GetDepartmentCourses(int id)
        {
            var courses = db.Courses.Where(c=>c.DepartmentID == id).Select(cc => new { cc.ID, cc.Name, cc.Description, cc.DepartmentID, deptname = cc.Department.Name, cc.Photo });
            
            if (courses == null)
            {
                return BadRequest();
            }
            return Ok(courses);
        }

        [Route("api/GetInstructorCourses/{id}")]
        public IHttpActionResult GetInstructorCourses(int id)
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
        public IHttpActionResult Edit([FromUri]int id, [FromBody] Cours cours)
        {
            Cours cs = db.Courses.Find(id);
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
        [ResponseType(typeof(Cours))]
        [HttpPost]
        public IHttpActionResult Add(Cours cours)
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
        [ResponseType(typeof(Cours))]
        public IHttpActionResult Delete(int id)
        {
            Cours cours = db.Courses.Find(id);
            if (cours == null)
            {
                return NotFound();
            }

            db.delete_Courses(id);

            return Ok(cours);
        }

        [ResponseType(typeof(Cours))]
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
