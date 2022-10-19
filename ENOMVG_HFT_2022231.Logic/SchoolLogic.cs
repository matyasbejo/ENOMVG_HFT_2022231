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
        IRepository<School> ScRepo;

        public SchoolLogic(IRepository<School> _screpo)
        {
            ScRepo = _screpo;
        }

        public void Create(School item)
        {
             this.ScRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.ScRepo.Delete(id);
        }

        public School Read(int id)
        {
            var school = this.ScRepo.Read(id);
            if (school == null)
            {
                throw new ArgumentException("Movie not exists");
            }

            return school;
        }

        public IQueryable<School> ReadAll()
        {
            return this.ScRepo.ReadAll();
        }

        public void Update(School school)
        {
            this.ScRepo.Update(school);
        }
    }
}
