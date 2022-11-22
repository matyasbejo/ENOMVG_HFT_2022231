using ENOMVG_HFT_2022231.Models;
using System.Linq;

namespace ENOMVG_HFT_2022231.Logic
{
    public interface ISchoolLogic
    {
        void Create(School _item);
        void Delete(int _id);
        School Read(int _id);
        IQueryable<School> ReadAll();
        void Update(School _school);
    }
}