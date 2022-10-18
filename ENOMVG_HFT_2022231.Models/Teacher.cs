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
        public int Id { get; set;}

        [Required]
        public string Name { get; set;}

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
            Id = id;
            Name = name;
            MainSubject = subject;
            SchoolId = schoolId;
        }

        public Teacher(string input)
        {
            string[] inputArr = input.Split("#");
            Id = int.Parse(inputArr[0]); //must specify auto generated keys in hasdata
            Name = inputArr[1];
            MainSubject = inputArr[2];
            SchoolId = int.Parse(inputArr[3]);
        }
    }
}
