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
        [ForeignKey("SchoolId")]
        public int SchoolId { get; set; }

        [Required]
        [Range(6,28)]
        public int StudentAge { get; set; }

        [Range(1.00,5.00)]
        public double StudentGradesAVG { get; set; }

        public Student()
        {

        }

        public Student(int id, string Name, int Age, int schoolId, double studentGradesAVG)
        {
            StudentName = Name;
            SchoolId = schoolId;
            StudentAge = Age;
            StudentId = id;
            StudentGradesAVG = studentGradesAVG;
        }

        public Student(string input)
        {
            string[] inputArr = input.Split("#");
            StudentId = int.Parse(inputArr[0]); //must specify auto generated keys in hasdata
            StudentName = inputArr[1];
            StudentAge = int.Parse(inputArr[2]);
            SchoolId = int.Parse(inputArr[3]);
        }
    }
}
