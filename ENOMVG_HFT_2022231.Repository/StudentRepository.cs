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
        public StudentRepository(SchollingDbContext _ctx) : base(_ctx)
        {

        }
        public override Student Read(int _id)
        {
            return this.context.Students.First(x => x.Id == _id);
        }

        public override void Update(Student _item)
        {
            var old = Read(_item.Id);
            foreach (var property in old.GetType().GetProperties())
            {
                property.SetValue(old, property.GetValue(_item));
            }
            context.SaveChanges();
        }
    }
}
