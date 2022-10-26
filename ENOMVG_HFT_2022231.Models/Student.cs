using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public virtual School School { get; set; }

        [Required]
        [Range(6,28)]
        public int Age { get; set; }

        [Range(1.00,5.00)]
        public double GradesAVG { get; set; }

        public Student()
        {

        }

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="school"></param>
        /// <param name="schoolId"></param>
        /// <param name="gradesAVG"></param>
        public Student(string Name, int Age, School school, int schoolId, double gradesAVG)
            :this(Name, Age, schoolId, gradesAVG)
        {
            this.School = school;
        }

        /// <summary>
        /// this constructor is only used in DbContext
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="school"></param>
        /// <param name="schoolId"></param>
        /// <param name="gradesAVG"></param>
        public Student(int id, string Name, int Age,  int schoolId, double gradesAVG)
            : this(Name, Age, schoolId, gradesAVG)
        {
            Id = id;
        }
        
        /// <summary>
        /// Base constuctor
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="schoolId"></param>
        /// <param name="gradesAVG"></param>
        private Student(string Name, int Age, int schoolId, double gradesAVG)
        {
            this.Name = Name;
            SchoolId = schoolId;
            this.Age = Age;
            GradesAVG = gradesAVG;
        }
    }
}
