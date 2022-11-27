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
                    id = int.Parse(Console.ReadLine());
                    School sch = rest.Get<School>(id, "school");

                    Console.WriteLine("Enter School's  ..... to update. Leave empty if you dont want to update the property");
                    Console.Write("                    Name: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null") sch.Name = res;
                    Console.Write("                    Type (Primary/Secondary/High): ");
                    res = Console.ReadLine();
                    if(res != null && res != "null") sch.Type = (stype)Enum.Parse(typeof(stype), res);

                    rest.Put(sch, "school");
                    break;

                case "Student":
                    Console.WriteLine("Enter Student's id to update: ");
                    id = int.Parse(Console.ReadLine());
                    Student st = rest.Get<Student>(id, "student");

                    Console.WriteLine("Enter Student's  ..... to update. Leave empty if you dont want to update the property");
                    Console.Write("           Name: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null")  st.Name = res;
                    Console.Write("           Age: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null")  st.Age = int.Parse(res);
                    Console.Write("           GradesAVG: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null")  st.GradesAVG = double.Parse(res);
                    Console.Write("           School Id: ");
                    res = Console.ReadLine();
                    if (res != null && res != "null")  st.SchoolId = int.Parse(res);

                    rest.Put(st, "student");
                    break;

                case "Teacher":
                    Console.WriteLine("Enter Teacher's id to update: ");
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


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:15398/");
            
            var schoolSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("School"))
                .Add("Create", () => Create("School"))
                .Add("Delete", () => Delete("School"))
                .Add("Update", () => Update("School"))
                .Add("Exit", ConsoleMenu.Close);

            var studentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Student"))
                .Add("Create", () => Create("Student"))
                .Add("Delete", () => Delete("Student"))
                .Add("Update", () => Update("Student"))
                .Add("Exit", ConsoleMenu.Close);

            var teacherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Teacher"))
                .Add("Create", () => Create("Teacher"))
                .Add("Delete", () => Delete("Teacher"))
                .Add("Update", () => Update("Teacher"))
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
