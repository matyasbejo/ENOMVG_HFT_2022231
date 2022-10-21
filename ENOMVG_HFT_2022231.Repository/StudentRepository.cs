using ENOMVG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Repository
{
    public class StudentRepository : Repository<Student>, IRepository<Student>
    {
        public StudentRepository(SchollingDbContext ctx) : base(ctx)
        {

        }
        public override Student Read(int id)
        {
            return this.context.Students.First(x => x.Id == id);
        }

        public override void Update(Student item)
        {
            var old = Read(item.Id);
            foreach (var property in old.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(item));
            }
            context.SaveChanges();
        }
    }
}
