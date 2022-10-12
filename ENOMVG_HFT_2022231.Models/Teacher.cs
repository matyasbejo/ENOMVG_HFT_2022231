using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set;}

        [Required]
        public string TeacherName { get; set;}

        [Required]
        [ForeignKey("SchoolId")]
        public int SchoolId { get; set;}

        [Required]        
        public string MainSubject { get; set;}
        public Teacher()
        {

        }
        public Teacher(int id, string name, string subject, int schoolId)
        {
            TeacherId = id;
            TeacherName = name;
            MainSubject = subject;
            SchoolId = schoolId;
        }

        public Teacher(string input)
        {
            string[] inputArr = input.Split("#");
            TeacherId = int.Parse(inputArr[0]); //must specify auto generated keys in hasdata
            TeacherName = inputArr[1];
            MainSubject = inputArr[2];
            SchoolId = int.Parse(inputArr[3]);
        }
    }
}
