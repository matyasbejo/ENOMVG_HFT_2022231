using ENOMVG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected SchollingDbContext context;
        public Repository(SchollingDbContext context)
        {
            this.context = context;
        }
        public void Create(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Set<T>().Remove(Read(id));
            context.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return context.Set<T>();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}
