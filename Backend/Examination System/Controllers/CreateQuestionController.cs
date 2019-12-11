using Examination_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Examination_System.Controllers
{
    public class CreateQuestionController : ApiController
    {
        private DBEntities db = new DBEntities();

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
    }
}
