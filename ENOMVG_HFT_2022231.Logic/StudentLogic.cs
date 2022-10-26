using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENOMVG_HFT_2022231.Repository;
using ENOMVG_HFT_2022231.Models;

namespace ENOMVG_HFT_2022231.Logic
{
    public class StudentLogic : IStudentLogic
    {
        IRepository<Student> repository;

        public StudentLogic(IRepository<Student> _strepo)
        {
            repository = _strepo;
        }

        public void Create(Student item)
        {
            this.repository.Create(item);
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public Student Read(int id)
        {
            var student = this.repository.Read(id);
            if (student == null)
            {
                throw new ArgumentException("Movie not exists");
            }

            return student;
        }
        public IQueryable<Student> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(Student student)
        {
            this.repository.Update(student);
        }
        //Non CRUD methods
        /// <summary>
        /// Read metódus név alapján - lassabb
        /// </summary>
        public Student ReadName(string name)
        {
            IQueryable<Student> all = this.repository.ReadAll();
            return all.First(t => t.Name.Equals(name));
        }

        /// <summary>
        /// Returns the student with the biggest avarage grade
        /// </summary>
        /// <returns></returns>
        public Student BestStudent()
        {
            IQueryable<Student> students = this.repository.ReadAll();
            double bestavg = students.Max(t => t.GradesAVG);
            return students.First(t => t.GradesAVG == bestavg);
        }

        /// <summary>
        /// Returns the avarage age of students
        /// </summary>
        /// <returns></returns>
        public int AvarageAge()
        {
            IQueryable<Student> students = this.repository.ReadAll();
            int sum = students.Sum(t => t.Age) / students.Count();
            return sum;
        }

        /// <summary>
        /// Returns the students under the avarage age
        /// </summary>
        /// <returns></returns>
        public IQueryable<Student> YoungStudents()
        {
            int avgAge = this.AvarageAge();
            IQueryable<Student> all = this.repository.ReadAll();
            return all.Where(t => t.Age <= avgAge);
        }
    }
}
