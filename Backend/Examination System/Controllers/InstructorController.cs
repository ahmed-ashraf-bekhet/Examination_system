﻿using System;
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
        private DBEntities db = new DBEntities();

        // GET: api/Instructor/5
        [HttpGet]
        public IHttpActionResult GetInstructor(int id)
        {
            var instructor = db.Instructors.Where(s => s.ID == id).Select(i => new { i.ID, i.Name, i.Username, i.Password, i.Photo, i.IsAdmin }).SingleOrDefault();
            if (instructor == null)
                return NotFound();

            return Ok(instructor);
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