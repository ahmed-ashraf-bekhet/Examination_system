using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_Of_Project.Models
{
    public class CreateQuestion
    {
        public string Question { get; set; }
        public int courseID { get; set; }
        public int TypeID { get; set; }
        public List<string> Answer { get; set; }
        public int R_Answer { get; set; }
    }
}