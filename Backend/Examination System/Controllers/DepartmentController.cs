using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Examination_System.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Diagnostics;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Newtonsoft.Json.Linq;
using Examination_System.Models;

namespace Examination_System.Controllers
{
    public class DepartmentController : ApiController
    {

         private DBEntities db = new DBEntities(); 

        
        //return All Depts
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var Departments = db.get_department().ToList();
            if (Departments == null)
                return NotFound();
            else
                return Ok(Departments);
        }


        //return one Dept
        [HttpGet]
        public IHttpActionResult GetDepartment(int? id)
        {
            var Department = db.Departments.Where(d => d.ID == id).Select(dd => new { dd.ID, dd.Name, dd.Photo}).SingleOrDefault();
            if (Department == null)
                return NotFound();
            else
                return Ok(Department);
        }

        [HttpGet]
        [Route("api/getStudentsNumber/{deptID}")]
        public IHttpActionResult GetStudentsNumber(int deptID)
        {
            return Ok(db.Students.Count(s => s.DepartmentID == deptID));
        }

        [HttpGet]
        [Route("api/getInstructorsNumber/{deptID}")]
        public IHttpActionResult GetInstructorsNumber(int deptID)
        {
            return Ok(db.Instructors.Count(i => i.DepartmentID == deptID));
        }

        [HttpGet]
        [Route("api/getCoursesNumber/{deptID}")]
        public IHttpActionResult GetCoursesNumber(int deptID)
        {
            return Ok(db.Courses.Count(c => c.DepartmentID == deptID));
        }

        //Delete one Dept
        [HttpGet]
        [Route("api/department/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int isAdmin = Int32.Parse(Request.Headers.GetValues("isAdmin").FirstOrDefault());
                if (isAdmin == 0)
                    return Unauthorized();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Unauthorized();
            }

            Department Department = db.Departments.Find(id);
            if (Department == null)
            {
                return NotFound();
            }
                
            db.delete_department(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //Update one Dept
        [HttpPost]
        [Route("api/department/update")]
        public IHttpActionResult Update(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(department).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartMentExists(department.ID))
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

<<<<<<< HEAD

=======
>>>>>>> master
        //Add Departmanet
        [HttpPost]
        [Route("api/department/add")]
        public IHttpActionResult Add(Department department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Departments.Add(department);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return BadRequest("unique");
            }

            return StatusCode(HttpStatusCode.Created);
        }

        //check if Department is exist or not
        private bool DepartMentExists(int id)
        {
            return db.Departments.Count(d => d.ID == id) > 0;
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
}