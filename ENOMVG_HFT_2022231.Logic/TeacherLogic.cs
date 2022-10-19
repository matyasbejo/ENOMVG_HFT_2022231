using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENOMVG_HFT_2022231.Repository;
using ENOMVG_HFT_2022231.Models;

namespace ENOMVG_HFT_2022231.Logic
{
    internal class TeacherLogic
    {
        IRepository<Teacher> TchRepo;

        public TeacherLogic(IRepository<Teacher> _tchrepo)
        {
            TchRepo = _tchrepo;
        }

        public void Create(Teacher item)
        {
            this.TchRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.TchRepo.Delete(id);
        }

        public Teacher Read(int id)
        {
            var teacher = this.TchRepo.Read(id);
            if (teacher == null)
            {
                throw new ArgumentException("Movie not exists");
            }

            return teacher;
        }

        public IQueryable<Teacher> ReadAll()
        {
            return this.TchRepo.ReadAll();
        }

        public void Update(Teacher teacher)
        {
            this.TchRepo.Update(teacher);
        }
    }
}
