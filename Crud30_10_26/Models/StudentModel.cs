using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crud30_10_26.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public DateTime dob { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public string password { get; set; }
    }
}