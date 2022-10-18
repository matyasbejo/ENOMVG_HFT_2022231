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
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("SchoolId")]
        public int SchoolId { get; set; }

        [Required]
        [Range(6,28)]
        public int Age { get; set; }

        [Range(1.00,5.00)]
        public double GradesAVG { get; set; }

        public Student()
        {

        }

        public Student(int id, string Name, int Age, int schoolId, double gradesAVG)
        {
            this.Name = Name;
            SchoolId = schoolId;
            this.Age = Age;
            Id = id;
            GradesAVG = gradesAVG;
        }

        public Student(string input)
        {
            string[] inputArr = input.Split("#");
            Id = int.Parse(inputArr[0]); //must specify auto generated keys in hasdata
            Name = inputArr[1];
            Age = int.Parse(inputArr[2]);
            SchoolId = int.Parse(inputArr[3]);
        }
    }
}
