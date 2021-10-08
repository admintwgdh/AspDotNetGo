using FreeSql.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace AspDotNetGo.Models
{
    public class StudentDto
    {
        public string Name { get; set; }
        public decimal Age { get; set; }
        public string Sex { get; set; }
        public string type { get; set; } = "after mapper";
    }
}
