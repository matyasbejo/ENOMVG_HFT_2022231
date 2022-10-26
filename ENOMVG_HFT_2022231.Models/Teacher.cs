using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Models
{
    public enum subj
    {
        ESTeacher, //elementary school teacher (magyar tanító)
        History,
        Physics,
        German,
        Geoghraphy,
        PE,
        IT,
        English,
        Literature
    }
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

        public virtual School School { get; set; }

        [Required]        
        public subj MainSubject { get; set;}
        
        [Required]
        public int Salary { get; set; }

        public Teacher()
        {

        }

        /// <summary>
        ///Main constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        /// <param name="subject"></param>
        /// <param name="school"></param>
        /// <param name="schoolId"></param>
        public Teacher(string name, int salary, subj subject, School school, int schoolId)
            :this(name,salary,subject,schoolId)
        {
            this.School = school;
        }

        /// <summary>
        /// this constructor is only used in DbContext
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        /// <param name="subject"></param>
        /// <param name="schoolId"></param>
        public Teacher(int id, string name, int salary, subj subject, int schoolId)
            : this(name, salary, subject, schoolId)    
        {
            Id = id;
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="salary"></param>
        /// <param name="subject"></param>
        /// <param name="schoolId"></param>
        private Teacher(string name, int salary, subj subject, int schoolId)
        {
            Name = name;
            MainSubject = subject;
            SchoolId = schoolId;
            Salary = salary;
        }
    }
}
