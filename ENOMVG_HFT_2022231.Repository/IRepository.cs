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
        void Create(T _item);
        T Read(int _id);
        IQueryable<T> ReadAll();
        void Update(T _school);
        void Delete(int _id);
    }
}
