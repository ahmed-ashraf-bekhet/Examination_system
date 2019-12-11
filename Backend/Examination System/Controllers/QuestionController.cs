using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Examination_System.Models;

namespace Pro_Test3_API.Controllers
{
    public class QuestionController : ApiController
    {
        DBEntities db = new DBEntities();

        [HttpGet]
        [Route("api/coursequestion/{id}")]
        public IHttpActionResult GetCourseQuestions(int id)
        {
            var crs = db.Courses.FirstOrDefault(c => c.ID == id);
            if (crs == null)
                return NotFound();
            else
                return Ok(crs.Questions.Select(q => new { q.ID, q.Body, q.Right_AnswerID, answers = q.Answers.Select(a => new { a.ID, a.Body }) }));
        }
        [HttpGet]
        [Route("api/questiontype")]
        public IHttpActionResult GetQuestionType()
        {
            return Ok(db.Question_Types.Select(q => q.Name));
        }

        //[HttpGet]
        [Route("api/questions/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            //var ex = db.Exams.Select(ex_qu => ex_qu.Questions.Select(ex_quu => ex_quu.ID == id)) as Question;
            Question q = db.Questions.FirstOrDefault(qq => qq.ID == id);


            db.Questions.Remove(q);
            db.SaveChanges();

            return Ok(new { msg = "Removed..." });
        }
        [HttpPost]
        public IHttpActionResult PostNewQuestion(Question question)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new DBEntities())
            {
                ctx.Questions.Add(new Question()
                {
                    Body = question.Body,
                    CourseID = question.CourseID,
                    TypeID = question.TypeID,
                    Right_AnswerID = question.Right_AnswerID
                });

                ctx.SaveChanges();
            }

            return Ok(new { msg = "Saved..." });
        }

        [HttpPut]
        [Route("api/EditQuestion/{id}")]
        public IHttpActionResult PutQuestionBody([FromUri]int id, [FromBody]string body)
        {
            Question q = db.Questions.FirstOrDefault(qq => qq.ID == id);

            if (q == null)
                return NotFound();
            else
            {
                q.Body = body;
                db.SaveChanges();
                return Ok(new { msg = "Edited..." });
            }

        }


    }
}
