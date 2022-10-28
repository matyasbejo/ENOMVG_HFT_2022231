using ENOMVG_HFT_2022231.Models;
using System.Linq;

namespace ENOMVG_HFT_2022231.Logic
{
    public interface ISchoolLogic
    {
        int CountAll(int _id);
        void Create(School _item);
        void Delete(int _id);
        double GetSchoolAVG(int _schoolId);
        School Read(int _id);
        IQueryable<School> ReadAll();
        School ReadName(string _name);
        void Update(School _school);
    }
}