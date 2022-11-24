using ENOMVG_HFT_2022231.Logic;
using ENOMVG_HFT_2022231.Models;
using ENOMVG_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.Test
{
    [TestFixture]
    internal class StudentTester
    {
        StudentLogic logic;
        Mock<IRepository<Student>> MockStudentRepository;

        [SetUp]
        public void Init()
        {
            var input = new List<Student>()
            {
                new Student(1, "Elso Diak", 17, 1, 5),
                new Student(2, "Masodik Diak", 7, 2, 3),
                new Student(3, "Harmadik Diak", 14, 1, 3.5)
            }.AsQueryable();
            MockStudentRepository = new Mock<IRepository<Student>>();
            MockStudentRepository.Setup(s => s.ReadAll()).Returns(input);
            MockStudentRepository.Setup(s => s.Read(1)).Returns(input.First(st => st.Id == 1));
            MockStudentRepository.Setup(s => s.Read(2)).Returns(input.First(s => s.Id == 2));
            MockStudentRepository.Setup(s => s.Read(3)).Returns(input.First(s => s.Id == 3));
            logic = new StudentLogic(MockStudentRepository.Object);
        }

        [Test]
        public void BestStudentTester()
        {
            Student st = logic.BestStudent();

            Assert.True(st.Equals(logic.Read(1)));
        }

        [Test]
        public void AvarageAgeTester()
        {
            int avgA = logic.AvarageAge();

            Assert.That(avgA == 12);
        }
    }
}
