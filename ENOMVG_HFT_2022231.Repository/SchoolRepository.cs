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
        public SchoolRepository(SchollingDbContext _ctx) : base(_ctx)
        {

        }
        public override School Read(int _id)
        {
            return this.context.Schools.First(x => x.Id == _id);
        }

        public override void Update(School _item)
        {
            var old = Read(_item.Id);
            foreach (var property in old.GetType().GetProperties())
            {
                if(property.Name != "Students" && property.Name != "Teachers" && property.Name != "LazyLoader") property.SetValue(old, property.GetValue(_item));
            }
            context.SaveChanges();
        }
    }
}
