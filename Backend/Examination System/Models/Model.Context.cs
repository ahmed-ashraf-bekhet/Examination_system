﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Examination_System.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Courses_Students> Courses_Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Question_Types> Question_Types { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Students_Exams_Answers> Students_Exams_Answers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
    
        public virtual int correct_exam(Nullable<int> examID, Nullable<int> studentID)
        {
            var examIDParameter = examID.HasValue ?
                new ObjectParameter("examID", examID) :
                new ObjectParameter("examID", typeof(int));
    
            var studentIDParameter = studentID.HasValue ?
                new ObjectParameter("studentID", studentID) :
                new ObjectParameter("studentID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("correct_exam", examIDParameter, studentIDParameter);
        }
    
        public virtual int CreateQuestion(string question, Nullable<int> courseID, Nullable<int> typeID, Nullable<int> r_Answer)
        {
            var questionParameter = question != null ?
                new ObjectParameter("Question", question) :
                new ObjectParameter("Question", typeof(string));
    
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("courseID", courseID) :
                new ObjectParameter("courseID", typeof(int));
    
            var typeIDParameter = typeID.HasValue ?
                new ObjectParameter("TypeID", typeID) :
                new ObjectParameter("TypeID", typeof(int));
    
            var r_AnswerParameter = r_Answer.HasValue ?
                new ObjectParameter("R_Answer", r_Answer) :
                new ObjectParameter("R_Answer", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateQuestion", questionParameter, courseIDParameter, typeIDParameter, r_AnswerParameter);
        }
    
        public virtual int delete_answer(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_answer", idParameter);
        }
    
        public virtual int delete_Courses(Nullable<int> coursesid)
        {
            var coursesidParameter = coursesid.HasValue ?
                new ObjectParameter("coursesid", coursesid) :
                new ObjectParameter("coursesid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_Courses", coursesidParameter);
        }
    
        public virtual int delete_courses_students(Nullable<int> courseid, Nullable<int> studentid)
        {
            var courseidParameter = courseid.HasValue ?
                new ObjectParameter("courseid", courseid) :
                new ObjectParameter("courseid", typeof(int));
    
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_courses_students", courseidParameter, studentidParameter);
        }
    
        public virtual int delete_department(Nullable<int> dept_id)
        {
            var dept_idParameter = dept_id.HasValue ?
                new ObjectParameter("dept_id", dept_id) :
                new ObjectParameter("dept_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_department", dept_idParameter);
        }
    
        public virtual int delete_exams(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_exams", idParameter);
        }
    
        public virtual int delete_instructor(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_instructor", idParameter);
        }
    
        public virtual int delete_question(Nullable<int> q)
        {
            var qParameter = q.HasValue ?
                new ObjectParameter("q", q) :
                new ObjectParameter("q", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_question", qParameter);
        }
    
        public virtual int delete_questionsTypes(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_questionsTypes", idParameter);
        }
    
        public virtual int delete_Students(Nullable<int> studentid)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_Students", studentidParameter);
        }
    
        public virtual int delete_students_exams_answers(Nullable<int> studentid, Nullable<int> questionid, Nullable<int> examid)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            var questionidParameter = questionid.HasValue ?
                new ObjectParameter("questionid", questionid) :
                new ObjectParameter("questionid", typeof(int));
    
            var examidParameter = examid.HasValue ?
                new ObjectParameter("examid", examid) :
                new ObjectParameter("examid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_students_exams_answers", studentidParameter, questionidParameter, examidParameter);
        }
    
        public virtual int delete_topics(Nullable<int> topicid)
        {
            var topicidParameter = topicid.HasValue ?
                new ObjectParameter("topicid", topicid) :
                new ObjectParameter("topicid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_topics", topicidParameter);
        }
    
        public virtual int generate_exam(Nullable<int> courseID, Nullable<int> tf_number, Nullable<int> mcq_number, Nullable<int> duration, string title)
        {
            var courseIDParameter = courseID.HasValue ?
                new ObjectParameter("courseID", courseID) :
                new ObjectParameter("courseID", typeof(int));
    
            var tf_numberParameter = tf_number.HasValue ?
                new ObjectParameter("tf_number", tf_number) :
                new ObjectParameter("tf_number", typeof(int));
    
            var mcq_numberParameter = mcq_number.HasValue ?
                new ObjectParameter("mcq_number", mcq_number) :
                new ObjectParameter("mcq_number", typeof(int));
    
            var durationParameter = duration.HasValue ?
                new ObjectParameter("duration", duration) :
                new ObjectParameter("duration", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("generate_exam", courseIDParameter, tf_numberParameter, mcq_numberParameter, durationParameter, titleParameter);
        }
    
        public virtual ObjectResult<get_Courses_by_departmentid_Result> get_Courses_by_departmentid(Nullable<int> departmentid)
        {
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_Courses_by_departmentid_Result>("get_Courses_by_departmentid", departmentidParameter);
        }
    
        public virtual ObjectResult<get_Courses_by_instructorid_Result> get_Courses_by_instructorid(Nullable<int> instructorid)
        {
            var instructoridParameter = instructorid.HasValue ?
                new ObjectParameter("instructorid", instructorid) :
                new ObjectParameter("instructorid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_Courses_by_instructorid_Result>("get_Courses_by_instructorid", instructoridParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> get_courses_students(Nullable<int> courseid, Nullable<int> studentid)
        {
            var courseidParameter = courseid.HasValue ?
                new ObjectParameter("courseid", courseid) :
                new ObjectParameter("courseid", typeof(int));
    
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("get_courses_students", courseidParameter, studentidParameter);
        }
    
        public virtual ObjectResult<get_courses_students_by_StudentID_Result> get_courses_students_by_StudentID(Nullable<int> studentid)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_courses_students_by_StudentID_Result>("get_courses_students_by_StudentID", studentidParameter);
        }
    
        public virtual ObjectResult<get_courses_students_number_by_instructorid_Result> get_courses_students_number_by_instructorid(Nullable<int> instructorid)
        {
            var instructoridParameter = instructorid.HasValue ?
                new ObjectParameter("instructorid", instructorid) :
                new ObjectParameter("instructorid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_courses_students_number_by_instructorid_Result>("get_courses_students_number_by_instructorid", instructoridParameter);
        }
    
        public virtual ObjectResult<get_department_Result> get_department()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_department_Result>("get_department");
        }
    
        public virtual ObjectResult<get_exams_Result> get_exams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_exams_Result>("get_exams");
        }
    
        public virtual ObjectResult<get_exams_questions_Result> get_exams_questions()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_exams_questions_Result>("get_exams_questions");
        }
    
        public virtual ObjectResult<get_questions_Answers_by_ExamID_Result> get_questions_Answers_by_ExamID(Nullable<int> exam_id)
        {
            var exam_idParameter = exam_id.HasValue ?
                new ObjectParameter("exam_id", exam_id) :
                new ObjectParameter("exam_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_questions_Answers_by_ExamID_Result>("get_questions_Answers_by_ExamID", exam_idParameter);
        }
    
        public virtual ObjectResult<get_questions_by_ExamID_Result> get_questions_by_ExamID(Nullable<int> exam_id)
        {
            var exam_idParameter = exam_id.HasValue ?
                new ObjectParameter("exam_id", exam_id) :
                new ObjectParameter("exam_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_questions_by_ExamID_Result>("get_questions_by_ExamID", exam_idParameter);
        }
    
        public virtual ObjectResult<get_questionsTypes_Result> get_questionsTypes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_questionsTypes_Result>("get_questionsTypes");
        }
    
        public virtual ObjectResult<get_student_answers_Result> get_student_answers(Nullable<int> exam_id, Nullable<int> student_id)
        {
            var exam_idParameter = exam_id.HasValue ?
                new ObjectParameter("exam_id", exam_id) :
                new ObjectParameter("exam_id", typeof(int));
    
            var student_idParameter = student_id.HasValue ?
                new ObjectParameter("student_id", student_id) :
                new ObjectParameter("student_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_student_answers_Result>("get_student_answers", exam_idParameter, student_idParameter);
        }
    
        public virtual ObjectResult<get_student_info_by_departmentid_Result> get_student_info_by_departmentid(Nullable<int> departmentid)
        {
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_student_info_by_departmentid_Result>("get_student_info_by_departmentid", departmentidParameter);
        }
    
        public virtual ObjectResult<get_Students_by_departmentid_Result> get_Students_by_departmentid(Nullable<int> departmentid)
        {
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_Students_by_departmentid_Result>("get_Students_by_departmentid", departmentidParameter);
        }
    
        public virtual ObjectResult<get_Students_by_studentid_Result> get_Students_by_studentid(Nullable<int> studentid)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_Students_by_studentid_Result>("get_Students_by_studentid", studentidParameter);
        }
    
        public virtual ObjectResult<get_topics_by_courseid_Result> get_topics_by_courseid(Nullable<int> courseid)
        {
            var courseidParameter = courseid.HasValue ?
                new ObjectParameter("courseid", courseid) :
                new ObjectParameter("courseid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_topics_by_courseid_Result>("get_topics_by_courseid", courseidParameter);
        }
    
        public virtual int insert_Course(string name, Nullable<int> departmentid, Nullable<int> instructorid)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            var instructoridParameter = instructorid.HasValue ?
                new ObjectParameter("instructorid", instructorid) :
                new ObjectParameter("instructorid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_Course", nameParameter, departmentidParameter, instructoridParameter);
        }
    
        public virtual int insert_courses_students(Nullable<int> courseid, Nullable<int> studentid, Nullable<int> grade)
        {
            var courseidParameter = courseid.HasValue ?
                new ObjectParameter("courseid", courseid) :
                new ObjectParameter("courseid", typeof(int));
    
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            var gradeParameter = grade.HasValue ?
                new ObjectParameter("grade", grade) :
                new ObjectParameter("grade", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_courses_students", courseidParameter, studentidParameter, gradeParameter);
        }
    
        public virtual int insert_department(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_department", nameParameter);
        }
    
        public virtual int insert_exam(string title, Nullable<int> duration, Nullable<System.DateTime> creationDateTime, Nullable<int> courseid)
        {
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            var durationParameter = duration.HasValue ?
                new ObjectParameter("duration", duration) :
                new ObjectParameter("duration", typeof(int));
    
            var creationDateTimeParameter = creationDateTime.HasValue ?
                new ObjectParameter("CreationDateTime", creationDateTime) :
                new ObjectParameter("CreationDateTime", typeof(System.DateTime));
    
            var courseidParameter = courseid.HasValue ?
                new ObjectParameter("courseid", courseid) :
                new ObjectParameter("courseid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_exam", titleParameter, durationParameter, creationDateTimeParameter, courseidParameter);
        }
    
        public virtual int insert_ListOFAnswers(string answer)
        {
            var answerParameter = answer != null ?
                new ObjectParameter("Answer", answer) :
                new ObjectParameter("Answer", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_ListOFAnswers", answerParameter);
        }
    
        public virtual int insert_questionsTypes(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_questionsTypes", nameParameter);
        }
    
        public virtual int insert_Student(string name, string username, string password, Nullable<int> departmentid)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_Student", nameParameter, usernameParameter, passwordParameter, departmentidParameter);
        }
    
        public virtual int insert_Student_Exam_Answer(Nullable<int> studentid, Nullable<int> questionID, Nullable<int> examID, Nullable<int> answerID)
        {
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            var questionIDParameter = questionID.HasValue ?
                new ObjectParameter("QuestionID", questionID) :
                new ObjectParameter("QuestionID", typeof(int));
    
            var examIDParameter = examID.HasValue ?
                new ObjectParameter("ExamID", examID) :
                new ObjectParameter("ExamID", typeof(int));
    
            var answerIDParameter = answerID.HasValue ?
                new ObjectParameter("AnswerID", answerID) :
                new ObjectParameter("AnswerID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_Student_Exam_Answer", studentidParameter, questionIDParameter, examIDParameter, answerIDParameter);
        }
    
        public virtual int insert_topic(string name, Nullable<int> courseid)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var courseidParameter = courseid.HasValue ?
                new ObjectParameter("courseid", courseid) :
                new ObjectParameter("courseid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insert_topic", nameParameter, courseidParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int update_Courses(string name, Nullable<int> departmentid, Nullable<int> instructorid, Nullable<int> coursesid)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            var instructoridParameter = instructorid.HasValue ?
                new ObjectParameter("instructorid", instructorid) :
                new ObjectParameter("instructorid", typeof(int));
    
            var coursesidParameter = coursesid.HasValue ?
                new ObjectParameter("coursesid", coursesid) :
                new ObjectParameter("coursesid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_Courses", nameParameter, departmentidParameter, instructoridParameter, coursesidParameter);
        }
    
        public virtual int update_courses_students(Nullable<int> courseid, Nullable<int> studentid, Nullable<int> grade)
        {
            var courseidParameter = courseid.HasValue ?
                new ObjectParameter("courseid", courseid) :
                new ObjectParameter("courseid", typeof(int));
    
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            var gradeParameter = grade.HasValue ?
                new ObjectParameter("grade", grade) :
                new ObjectParameter("grade", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_courses_students", courseidParameter, studentidParameter, gradeParameter);
        }
    
        public virtual int update_department(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_department", idParameter, nameParameter);
        }
    
        public virtual int update_exam(Nullable<int> id, string title)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_exam", idParameter, titleParameter);
        }
    
        public virtual int update_questionsTypes(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_questionsTypes", idParameter, nameParameter);
        }
    
        public virtual int update_Student(string name, string username, string password, Nullable<int> departmentid, Nullable<int> studentid)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var departmentidParameter = departmentid.HasValue ?
                new ObjectParameter("departmentid", departmentid) :
                new ObjectParameter("departmentid", typeof(int));
    
            var studentidParameter = studentid.HasValue ?
                new ObjectParameter("studentid", studentid) :
                new ObjectParameter("studentid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_Student", nameParameter, usernameParameter, passwordParameter, departmentidParameter, studentidParameter);
        }
    
        public virtual int update_topic(string name, Nullable<int> courseid, Nullable<int> topicid)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var courseidParameter = courseid.HasValue ?
                new ObjectParameter("courseid", courseid) :
                new ObjectParameter("courseid", typeof(int));
    
            var topicidParameter = topicid.HasValue ?
                new ObjectParameter("topicid", topicid) :
                new ObjectParameter("topicid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("update_topic", nameParameter, courseidParameter, topicidParameter);
        }
    }
}
