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
        public int SchoolId { get; set;}

        [ForeignKey("SchoolId")]
        public virtual School school { get; set; }

        [Required]        
        public string MainSubject { get; set;}
        public Teacher()
        {

        }
        public Teacher(string name, string subject)
        {
            TeacherName = name;
            MainSubject = subject;
        }

        public Teacher(string input)
        {
            string[] inputArr = input.Split("#");
            TeacherName = inputArr[0];
            MainSubject = inputArr[1];
            SchoolId = int.Parse(inputArr[2]);
        }
    }
}
