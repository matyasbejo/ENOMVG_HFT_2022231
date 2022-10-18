using ENOMVG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Repository
{
    internal class SchoolingRepository : ISchoolingRepository
    {
        SchollingDbContext context;
        public SchoolingRepository(SchollingDbContext context)
        {
            this.context = context;
        }
        public void Create(School school)
        {
            this.context.Schools.Add(school);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.context.Schools.Remove(Read(id));
            this.context.SaveChanges();
        }

        public School Read(int id)
        {
            return this.context.Schools.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<School> ReadAll()
        {
            return this.context.Schools;
        }

        public void Update(School school)
        {
            var oldschool = Read(school.Id);
            oldschool.Id = school.Id;
            oldschool.Name = school.Name;
            oldschool.Age = school.Age;
            oldschool.Type = school.Type;
            this.context.SaveChanges();
        }
    }
}
