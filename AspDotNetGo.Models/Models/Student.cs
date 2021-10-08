using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspDotNetGo.Models
{
    [Table(name: "student")]    //Freesql必须申明表名
    public partial class Student
    {
        public string Name { get; set; }
        public decimal Age { get; set; }
        public string Sex { get; set; }
        [Key]   //EF 必须有主键
        public string IdCard { get; set; }
    }
    public partial class Student
    {
        [NotMapped]
        public string type { get; set; } = "before mapper";
    }
}
