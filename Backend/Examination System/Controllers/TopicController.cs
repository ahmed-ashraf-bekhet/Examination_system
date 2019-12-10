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
    public class TopicController : ApiController
    {
        private ExaminationSystemDBEntities db = new ExaminationSystemDBEntities();

        [HttpGet]
        [Route("api/topic/getTopics/{courseID}")]
        public IHttpActionResult GetTopics(int courseID)
        {
            var topics = db.Topics.Where(t=>t.CourseID == courseID).Select(t => new { t.ID, t.Name });
            return Ok(topics);
        }

        // GET: api/Topic/5
        [ResponseType(typeof(Topic))]
        public IHttpActionResult GetTopic(int id)
        {
            var topic = db.Topics.Where(t => t.ID == id).Select(e => new { e.ID, e.Name });
            if (topic == null)
            {
                return NotFound();
            }

            return Ok(topic);
        }

        [HttpPost]
        [Route("api/topic/update")]
        public IHttpActionResult Update(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(topic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TopicExists(topic.ID))
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
        [Route("api/topic/add")]
        public IHttpActionResult Add(Topic topic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Topics.Add(topic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = topic.ID }, topic);
        }

        [HttpGet]
        [Route("api/topic/delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                int isAdmin = int.Parse(Request.Headers.GetValues("isAdmin").FirstOrDefault());
                if (isAdmin == 0)
                    return Unauthorized();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Unauthorized();
            }

            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return NotFound();
            }

            db.Topics.Remove(topic);
            db.SaveChanges();

            return Ok(topic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TopicExists(int id)
        {
            return db.Topics.Count(e => e.ID == id) > 0;
        }
    }
}