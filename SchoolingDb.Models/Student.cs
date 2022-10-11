using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public int SchoolId { get; set; }

        [ForeignKey("SchoolId")]
        public virtual School school { get; set; }

        [Required]
        [Range(6,28)]
        public int StudentAge { get; set; }

        public Student()
        {

        }

        public Student(string Name, int Age, int School, int id)
        {
            StudentName = Name;
            SchoolId = School;
            StudentAge = Age;
            StudentId = id;
        }

        public Student(string input)
        {
            string[] inputArr = input.Split("#");
            StudentName = inputArr[0];
            SchoolId = int.Parse(inputArr[1]);
            StudentAge = int.Parse(inputArr[2]);
        }
    }
}
