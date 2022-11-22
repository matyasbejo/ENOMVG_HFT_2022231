using ENOMVG_HFT_2022231.Models;
using System.Linq;

namespace ENOMVG_HFT_2022231.Logic
{
    public interface IStudentLogic
    {
        void Create(Student _item);
        void Delete(int _id);
        Student Read(int _id);
        IQueryable<Student> ReadAll();
        void Update(Student _student);
    }
}