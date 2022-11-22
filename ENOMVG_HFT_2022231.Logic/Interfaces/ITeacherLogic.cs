using ENOMVG_HFT_2022231.Models;
using System.Linq;

namespace ENOMVG_HFT_2022231.Logic
{
    public interface ITeacherLogic
    {
        void Create(Teacher _item);
        void Delete(int _id);
        Teacher Read(int _id);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher _teacher);
    }
}