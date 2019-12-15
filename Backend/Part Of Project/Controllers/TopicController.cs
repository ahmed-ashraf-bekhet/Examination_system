using CrystalDecisions.CrystalReports.Engine;
using Newtonsoft.Json.Linq;
using Part_Of_Project.Models;
using Part_Of_Project.Reports;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Part_Of_Project.Controllers
{
    public class TopicController : ApiController
    {
        private DBEntities db = new DBEntities();

        [HttpGet]
        [Route("api/topic/getTopics/{courseID}")]
        public IHttpActionResult GetTopics(int courseID)
        {
            var topics = db.Topics.Where(t => t.CourseID == courseID).Select(t => new { t.ID, t.Name });
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

            return StatusCode(HttpStatusCode.Created);
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
    }
}
