using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Models
{
    public class School
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SchoolId { get; set; }

        [Required]
        [StringLength(100)]
        public string SchoolName { get;}

        public int SchoolAge { get; set; }

        [Required]
        public string SchoolType { get; set; }  //jövőben enum

        public School()
        {

        }
        public School(string name, string type, int id)
        {
            SchoolName = name;
            SchoolType = type;
            SchoolId = id;
        }

        public School(string input)
        {
            string[] inputArr = input.Split("#");
            SchoolName = inputArr[0];
            SchoolType = inputArr[1];
        }

    }
}
