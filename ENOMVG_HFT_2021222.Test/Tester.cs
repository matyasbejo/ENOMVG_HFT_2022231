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
    internal class Tester
    {
        SchoolLogic logic;
        Mock<IRepository<School>> MockSchoolRepository;

        [SetUp]
        public void Init()
        {
            var input = new List<School>()
            {
                new School(1, "Elso Varosi Iskola", stype.Primary),
                new School(2, "Masodik Varosi Iskola", stype.High),
                new School(3, "Harmadik Varosi Iskola", stype.High)
            }.AsQueryable();
            MockSchoolRepository = new Mock<IRepository<School>>();
            MockSchoolRepository.Setup(s => s.ReadAll()).Returns(input);
            MockSchoolRepository.Setup(s => s.Read(1)).Returns(input.First(s => s.Id == 1));
            MockSchoolRepository.Setup(s => s.Read(2)).Returns(input.First(s => s.Id == 2));
            MockSchoolRepository.Setup(s => s.Read(3)).Returns(input.First(s => s.Id == 3));
            logic = new SchoolLogic(MockSchoolRepository.Object);
        }

        [Test]
        public void ReadNameTestWithExistingSchool()
        {
            School sch = logic.ReadName("Masodik Varosi Iskola");

            Assert.That(sch.Equals(logic.Read(2)));
        }

        [Test]
        public void ReadNameTestWithFakeSchool()
        {
            Assert.Throws<InvalidOperationException>(() => { logic.ReadName("exterminate"); });
        }

        [Test]



    }
}
