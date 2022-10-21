using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENOMVG_HFT_2022231.Repository;
using ENOMVG_HFT_2022231.Models;

namespace ENOMVG_HFT_2022231.Logic
{
    public class SchoolLogic
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
        public double GetSchoolAVG(int SchoolId)
        {
            School school = this.repository.Read(SchoolId);
            IQueryable<Student> students = 
        }
    }
}
