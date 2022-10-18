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
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set;}

        public int Age { get; set; }

        [Required]
        public string Type { get; set; }  //jövőben enum

        public School()
        {

        }
        public School(int id, string name, string type)
        {
            Name = name;
            Type = type;
            Id = id;
        }

        public School(string input)
        {
            string[] inputArr = input.Split("#");
            Id = int.Parse(inputArr[0]); //must specify auto generated keys in hasdata
            Name = inputArr[1];
            Type = inputArr[2];
        }

    }
}
