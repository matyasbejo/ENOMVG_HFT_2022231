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

        [JsonIgnore]
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
        /// <param name="_name"></param>
        /// <param name="_salary"></param>
        /// <param name="_subject"></param>
        /// <param name="_school"></param>
        /// <param name="_schoolid"></param>
        public Teacher(string _name, int _salary, subj _subject, School _school, int _schoolid)
            :this(_name,_salary,_subject,_schoolid)
        {
            this.School = _school;
        }

        /// <summary>
        /// this constructor is only used in DbContext
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="_name"></param>
        /// <param name="_salary"></param>
        /// <param name="_subject"></param>
        /// <param name="_schoolId"></param>
        public Teacher(int _id, string _name, int _salary, subj _subject, int _schoolId)
            : this(_name, _salary, _subject, _schoolId)    
        {
            Id = _id;
        }

        /// <summary>
        /// Base constructor
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_salary"></param>
        /// <param name="_subject"></param>
        /// <param name="_schoolId"></param>
        private Teacher(string _name, int _salary, subj _subject, int _schoolId)
        {
            Name = _name;
            MainSubject = _subject;
            SchoolId = _schoolId;
            Salary = _salary;
        }
    }
}
