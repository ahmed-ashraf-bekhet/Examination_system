﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Part_Of_Project.Models
{
    public class Email
    {
        public string to { get; set; }
        public string from { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}