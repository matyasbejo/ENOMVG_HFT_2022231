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
        


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:15398/", "schooling");
        }
    }
}
