using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Models
{
    public enum stype
    {
        Primary,
        Secondary, //középsuli
        High, //gimi

    }
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
        public stype Type { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }

        public School()
        {
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }
        public School(string name, stype type)
        {
            Name = name;
            Type = type;
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

        public School(int id, string name, stype type) : this(name, type)
        {
            Id = id;
        }

        public School(string input)
        {
            string[] inputArr = input.Split("#");
            Id = int.Parse(inputArr[0]); //must specify auto generated keys in hasdata
            Name = inputArr[1];
            Type = (stype)Enum.Parse(typeof(stype), inputArr[2]);
            Students = new HashSet<Student>();
            Teachers = new HashSet<Teacher>();
        }

    }
}
