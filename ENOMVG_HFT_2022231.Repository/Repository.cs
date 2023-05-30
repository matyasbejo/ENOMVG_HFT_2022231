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
        public Repository(SchollingDbContext _context)
        {
            this.context = _context;
        }
        public void Create(T _item)
        {
            context.Set<T>().Add(_item);
            try { context.SaveChanges(); }
            catch { };
        }

        public void Delete(int _id)
        {
            context.Set<T>().Remove(Read(_id));
            context.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return context.Set<T>();
        }

        public abstract T Read(int _id);
        public abstract void Update(T _item);
    }
}
