using ENOMVG_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace ENOMVG_HFT_2022231.Logic
{
    public interface IStudentLogic
    {
        double AvarageAge();
        Student BestStudent();
        void Create(Student _item);
        void Delete(int _id);
        Student Read(int _id);
        IQueryable<Student> ReadAll();
        Student ReadName(string _name);
        void Update(Student _student);
        IEnumerable<Student> YoungStudents();
    }
}