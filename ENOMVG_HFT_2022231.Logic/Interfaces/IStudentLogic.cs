using ENOMVG_HFT_2022231.Models;
using System.Linq;

namespace ENOMVG_HFT_2022231.Logic
{
    public interface IStudentLogic
    {
        int AvarageAge();
        Student BestStudent();
        void Create(Student item);
        void Delete(int id);
        Student Read(int id);
        IQueryable<Student> ReadAll();
        Student ReadName(string name);
        void Update(Student student);
        IQueryable<Student> YoungStudents();
    }
}