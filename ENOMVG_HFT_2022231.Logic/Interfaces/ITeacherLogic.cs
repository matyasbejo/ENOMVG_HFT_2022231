using ENOMVG_HFT_2022231.Models;
using System.Linq;

namespace ENOMVG_HFT_2022231.Logic
{
    public interface ITeacherLogic
    {
        void Create(Teacher item);
        void Delete(int id);
        Teacher LeastPaidTeacher();
        Teacher MostPaidTeacher();
        Teacher Read(int id);
        IQueryable<Teacher> ReadAll();
        Teacher ReadName(string name);
        void Update(Teacher teacher);
    }
}