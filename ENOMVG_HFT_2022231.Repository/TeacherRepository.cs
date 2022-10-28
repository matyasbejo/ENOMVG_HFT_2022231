using ENOMVG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Repository
{
    public class TeacherRepository : Repository<Teacher>, IRepository<Teacher>
    {
        public TeacherRepository(SchollingDbContext ctx) : base(ctx) 
        {

        }
        public override Teacher Read(int id)
        {
            return this.context.Teachers.First(x => x.Id == id);
        }

        public override void Update(Teacher item)
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
