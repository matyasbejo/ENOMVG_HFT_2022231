using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENOMVG_HFT_2022231.Repository;
using ENOMVG_HFT_2022231.Models;

namespace ENOMVG_HFT_2022231.Logic
{
    internal class StudentLogic
    {
        IRepository<Student> StRepo;

        public StudentLogic(IRepository<Student> _strepo)
        {
            StRepo = _strepo;
        }

        public void Create(Student item)
        {
            this.StRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.StRepo.Delete(id);
        }

        public Student Read(int id)
        {
            var student = this.StRepo.Read(id);
            if (student == null)
            {
                throw new ArgumentException("Movie not exists");
            }

            return student;
        }

        public IQueryable<Student> ReadAll()
        {
            return this.StRepo.ReadAll();
        }

        public void Update(Student student)
        {
            this.StRepo.Update(student);
        }
    }
}
