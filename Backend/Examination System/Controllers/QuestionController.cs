using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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


        [HttpPost]
        [Route("api/createQuestion")]
        public IHttpActionResult Add([FromBody]CreateQuestion CQ)
        {
            var Answer = new DataTable();
            Answer.Columns.Add("Answer", typeof(string));
            foreach (var item in CQ.Answer)
            {
                Answer.Rows.Add(item);
            }
            var parameter1 = new SqlParameter("Question", SqlDbType.NVarChar);
            parameter1.Value = CQ.Question;

            var parameter2 = new SqlParameter("courseID", SqlDbType.Int);
            parameter2.Value = CQ.courseID;

            var parameter3 = new SqlParameter("TypeID", SqlDbType.Int);
            parameter3.Value = CQ.TypeID;

            var parameter4 = new SqlParameter("@Answer", SqlDbType.Structured);
            parameter4.Value = Answer;
            parameter4.TypeName = "dbo.ListOFAnswers";

            var parameter5 = new SqlParameter("R_Answer", SqlDbType.Int);
            parameter5.Value = CQ.R_Answer;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Database.ExecuteSqlCommand("exec dbo.CreateQuestion @Question, @courseID, @TypeID, @Answer, @R_Answer", parameter1, parameter2, parameter3, parameter4, parameter5);

            return CreatedAtRoute("DefaultApi", new { Question = CQ.Question }, CQ);
        }


        //return All Types of Questions
        [HttpGet]
        [Route("api/Type")]
        public IHttpActionResult GetAll()
        {
            var Types = db.Question_Types.Select(s => new { s.ID, s.Name }).ToList();
            if (Types == null)
                return NotFound();
            else
                return Ok(Types);
        }

    }
}
