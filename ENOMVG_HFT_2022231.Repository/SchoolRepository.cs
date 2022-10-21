using ENOMVG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Repository
{
    public class SchoolRepository : Repository<School>, IRepository<School>
    {
        public SchoolRepository(SchollingDbContext ctx) : base(ctx)
        {

        }
        public override School Read(int id)
        {
            return this.context.Schools.First(x => x.Id == id);
        }

        public override void Update(School item)
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
