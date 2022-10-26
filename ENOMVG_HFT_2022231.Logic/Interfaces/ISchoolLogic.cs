using ENOMVG_HFT_2022231.Models;
using System.Linq;

namespace ENOMVG_HFT_2022231.Logic
{
    public interface ISchoolLogic
    {
        int CountAll(int id);
        void Create(School item);
        void Delete(int id);
        double GetSchoolAVG(int schoolId);
        School Read(int id);
        IQueryable<School> ReadAll();
        School ReadName(string name);
        void Update(School school);
    }
}