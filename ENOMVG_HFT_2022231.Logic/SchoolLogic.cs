using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENOMVG_HFT_2022231.Repository;
using ENOMVG_HFT_2022231.Models;

namespace ENOMVG_HFT_2022231.Logic
{
    public class SchoolLogic : ISchoolLogic
    {
        IRepository<School> repository;

        public SchoolLogic(IRepository<School> _screpo)
        {
            repository = _screpo;
        }
        public void Create(School item)
        {
            this.repository.Create(item);
        }
        public void Delete(int id)
        {
            this.repository.Delete(id);
        }
        public School Read(int id)
        {
            var school = this.repository.Read(id);
            if (school == null)
            {
                throw new ArgumentException("Movie not exists");
            }

            return school;
        }
        public IQueryable<School> ReadAll()
        {
            return this.repository.ReadAll();
        }
        public void Update(School school)
        {
            this.repository.Update(school);
        }
        //Non CRUD methods
        ///<summary>
        ///Visszaadja az iskolaba jaro diakok osszesitett atlagat
        ///</summary>
        public double GetSchoolAVG(int schoolId)
        {
            School school = Read(schoolId);
            ICollection<Student> students = school.Students;

            double sum = 0;
            foreach (Student st in students)
            {
                sum += st.GradesAVG;
            }
            return sum / students.Count();
        }
        /// <summary>
        /// Read metódus név alapján - lassabb
        /// </summary>
        public School ReadName(string name)
        {
            IQueryable<School> all = this.repository.ReadAll();
            return all.First(t => t.Name.Equals(name));
        }

        /// <summary>
        /// Returns how many people are working AND learning there
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountAll(int id)
        {
            School sch = repository.Read(id);
            return sch.Students.Count() + sch.Teachers.Count();
        }
    }
}
