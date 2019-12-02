using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Pro_Test3_API.Models;

namespace Pro_Test3_API.Controllers
{
    public class QuestionController : ApiController
    {

        ExaminationSystemDBEntities db = new ExaminationSystemDBEntities();

        [HttpGet]
        [Route("api/coursequestion/{id}")]
        public IHttpActionResult GetCourseQuestions(int id)
        {
            //employee ee = emps.Find(n => n.id == id);
            //student ee = db.students.FirstOrDefault(s => s.id == id);
            var q = db.Courses.Select(qq => new { qq.ID, question_id = qq.Questions.Select(c => new { c.ID, c.Body }) }).FirstOrDefault(qqq => qqq.ID == id);
            if (q == null)
                return NotFound();
            else
                return Ok(q);
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

            using (var ctx = new ExaminationSystemDBEntities())
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
