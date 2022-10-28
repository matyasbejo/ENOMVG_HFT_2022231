using ENOMVG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Repository
{
    public interface IRepository<T> where T : class
    {
        void Create(T item);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T school);
        void Delete(int id);
    }
}
