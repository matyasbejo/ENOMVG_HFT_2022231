using ENOMVG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Repository
{
    public interface IRepository
    {
        void Create(School school);
        School Read(int id);
        IQueryable<School> ReadAll();
        void Update(School school);
        void Delete(int id);
    }
}
