using ConsoleTools;
using ENOMVG_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace ENOMVG_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            string name;
            stype schtype;
            subj tsubj;
            int schoolid, age, salary;
            double gradesAVG;

            switch (entity)
            {
                case "School":
                    Console.WriteLine("Enter School ");
                    Console.Write("           Name: ");
                    name = Console.ReadLine();
                    Console.Write("           Type (Primary/Secondary/High): ");
                    schtype = (stype)Enum.Parse(typeof(stype), Console.ReadLine());

                    rest.Post(new School(name, schtype), "school");
                    break;

                case "Student":
                    Console.WriteLine("Enter Student ");
                    Console.Write("           Name: ");
                    name = Console.ReadLine();
                    Console.Write("           Age: ");
                    age = int.Parse(Console.ReadLine());
                    Console.Write("           GradesAVG: ");
                    gradesAVG = double.Parse(Console.ReadLine());
                    Console.Write("           School Id: ");
                    schoolid = int.Parse(Console.ReadLine());

                    rest.Post(new Student(name, age, null, schoolid, gradesAVG), "student");
                    break;

                case "Teacher":
                    Console.WriteLine("Enter Teacher ");
                    Console.Write("           Name: ");
                    name = Console.ReadLine();
                    Console.Write("           Salary: ");
                    salary = int.Parse(Console.ReadLine());
                    Console.Write("           School Id: ");
                    schoolid = int.Parse(Console.ReadLine());
                    Console.Write("Subject (ESTeacher/History/Physics/German/Geoghraphy/PE/IT/English/Literature): ");
                    tsubj = (subj)Enum.Parse(typeof(subj), Console.ReadLine());


                    rest.Post(new Teacher(name, salary, tsubj, null, schoolid), "teacher");
                    break;
            }
        }
        static void List(string entity)
        {
            switch (entity)
            {
                case "School":
                    List<School> schools = rest.Get<School>("school");
                    foreach (School school in schools)
                    {
                        Console.WriteLine(school.Name);
                    }
                    break;

                case "Student":
                    List<Student> students = rest.Get<Student>("student");
                    foreach (Student student in students)
                    {
                        Console.WriteLine(student.Name);
                    }
                    break;

                case "Teacher":
                    List<Teacher> teachers = rest.Get<Teacher>("teacher");
                    foreach (Teacher teacher in teachers)
                    {
                        Console.WriteLine(teacher.Name);
                    }
                    break;
            }
        }
        static void Delete(string entity)
        {
            int id;
            switch (entity)
            {
                case "School":
                    Console.Write("Enter School's id to delete: ");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "school");
                    break;

                case "Student":
                    Console.Write("Enter Student's id to delete: ");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "student");
                    break;

                case "Teacher":
                    Console.Write("Enter Teacher's id to delete: ");
                    id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "teacher");
                    break;
            }
        }
        static void Update(string entity)
        {
            string res;
            int id;
            switch (entity)
            {
                case "School":
                    Console.WriteLine("Enter School's id to update: ");
                    Console.Write("Enter School's id to update: ");
                    id = int.Parse(Console.ReadLine());
                    School sch = rest.Get<School>(id, "school");

                    Console.WriteLine("Enter School's  ..... to update. Leave empty if you dont want to update the property");
                    Console.Write("                    Name: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") sch.Name = res;
                    Console.Write("                    Type (Primary/Secondary/High): ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") sch.Type = (stype)Enum.Parse(typeof(stype), res);

                    rest.Put(sch, "school");
                    break;

                case "Student":
                    Console.WriteLine("Enter Student's id to update: ");
                    Console.Write("Enter Student's id to update: ");
                    id = int.Parse(Console.ReadLine());
                    Student st = rest.Get<Student>(id, "student");

                    Console.WriteLine("Enter Student's  ..... to update. Leave empty if you dont want to update the property");
                    Console.Write("           Name: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") st.Name = res;
                    Console.Write("           Age: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") st.Age = int.Parse(res);
                    Console.Write("           GradesAVG: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") st.GradesAVG = double.Parse(res);
                    Console.Write("           School Id: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") st.SchoolId = int.Parse(res);

                    rest.Put(st, "student");
                    break;

                case "Teacher":
                    Console.WriteLine("Enter Teacher's id to update: ");
                    Console.Write("Enter Teacher's id to update: ");
                    id = int.Parse(Console.ReadLine());
                    Teacher tch = rest.Get<Teacher>(id, "teacher");

                    Console.WriteLine("Enter Teacher's  ..... to update. Leave empty if you dont want to update the property");
                    Console.Write("           Name: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") tch.Name = res;
                    Console.Write("           Salary: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") tch.Salary = int.Parse(res);
                    Console.Write("           School Id: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") tch.SchoolId = int.Parse(res);
                    Console.Write("Subject (ESTeacher/History/Physics/German/Geoghraphy/PE/IT/English/Literature): ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") tch.MainSubject = (subj)Enum.Parse(typeof(subj), res);

                    rest.Put(tch, "teacher");
                    break;
            }

        }

        static void School_GradesAVG()
        {
            Console.Write("Iskola id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(rest.GetSingle<double>("/Statistics/School_GradesAvg/{id}"));
        }
        static void School_SalaryAVG()
        {
            Console.Write("Iskola id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(rest.GetSingle<double>("/Statistics/School_SalaryAVG/{id}"));
        }
        static void School_ReadName()
        {
            Console.Write("Diák neve: ");
            string name = Console.ReadLine();
            Console.WriteLine(rest.GetSingle<School>("/Statistics/School_GradesAvg/{name}"));
        }
        static void School_CountAll()
        {
            Console.Write("Iskola id: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine(rest.GetSingle<int>("/Statistics/School_CountAll/{id}"));
        }
        static void School_TeachersOfSchool()
        {
            Console.Write("Iskola id: ");
            int id = int.Parse(Console.ReadLine());
            var res = rest.GetSingle<IEnumerable<Teacher>>("/Statistics/School_TeachersOfSchool/{id}");

            foreach (var teacher in res)
            {
                Console.WriteLine(teacher.Name);
            }
        }

        static void Student_ReadName()
        {
            Console.Write("Diák neve: ");
            string name = Console.ReadLine();
            Console.WriteLine(rest.GetSingle<Student>("/Statistics/Student_ReadName/{name}"));
        }
        static void Student_BestStudent()
        {
            Console.WriteLine(rest.GetSingle<Student>("/Statistics/Student_BestStudent"));
        }
        static void Student_AvarageAge()
        {
            Console.WriteLine(rest.GetSingle<double>("/Statistics/Student_AvarageAge"));
        }
        static void Student_YoungStudents()
        {
            var res = rest.GetSingle<IEnumerable<Student>>("/Statistics/Student_YoungStudents");

            foreach (var student in res)
            {
                Console.WriteLine(student.Name);
            }
        }

        static void Teacher_Readname()
        {
            Console.Write("Tanár neve: ");
            string name = Console.ReadLine();
            Console.WriteLine(rest.GetSingle<Teacher>("/Statistics/Teacher_Readname/{name}").Name);
        }
        static void Teacher_MostPaidTeacher()
        {
            Console.WriteLine(rest.GetSingle<Teacher>("/Statistics/Teacher_MostPaidTeacher").Name);
        }
        static void Teacher_LeastPaidTeacher()
        {
            Console.WriteLine(rest.GetSingle<Teacher>("/Statistics/Teacher_LeastPaidTeacher").Name);
        }


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:15398/");

            var schoolSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("School"))
                .Add("Create", () => Create("School"))
                .Add("Delete", () => Delete("School"))
                .Add("Update", () => Update("School"))
                .Add("Grades_AVG", () => School_GradesAVG())
                .Add("Salary_AVG", () => School_SalaryAVG())
                .Add("ReadName", () => School_ReadName())
                .Add("CountAll", () => School_CountAll())
                .Add("TeachersOfSchool", () => School_TeachersOfSchool())
                .Add("Exit", ConsoleMenu.Close);

            var studentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Student"))
                .Add("Create", () => Create("Student"))
                .Add("Delete", () => Delete("Student"))
                .Add("Update", () => Update("Student"))
                .Add("Student_ReadName", () => Student_ReadName())
                .Add("Student_BestStudent", () => Student_BestStudent())
                .Add("Student_AvarageAge", () => Student_AvarageAge())
                .Add("Student_YoungStudents", () => Student_YoungStudents())
                .Add("Exit", ConsoleMenu.Close);

            var teacherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Teacher"))
                .Add("Create", () => Create("Teacher"))
                .Add("Delete", () => Delete("Teacher"))
                .Add("Update", () => Update("Teacher"))
                .Add("Readname",() => Teacher_Readname())
                .Add("MostPaidTeacher", () => Teacher_MostPaidTeacher())
                .Add("LeastPaidTeacher", () => Teacher_LeastPaidTeacher())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Schools", () => schoolSubMenu.Show())
                .Add("Students", () => studentSubMenu.Show())
                .Add("Teachers", () => teacherSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
