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
                new School(3, "Harmadik Varosi Iskola", stype.High),
                new School(4, "Negyedik Varosi Iskola", stype.Secondary)
            }.AsQueryable();
            MockSchoolRepository = new Mock<IRepository<School>>();
            MockSchoolRepository.Setup(m => m.ReadAll()).Returns(input);
            logic = new SchoolLogic(MockSchoolRepository.Object);
        }

        [Test]
        public void CreateNewSchoolTest()
        {

            var school = new School("Otodik Varosi Iskola", stype.Secondary);

            logic.Create(school);

            MockSchoolRepository.Verify(r => r.Create(school), Times.Once());
        }

        [Test]
        public void ReadExistingTest()
        {
            logic = new SchoolLogic(MockSchoolRepository.Object);
            var school = logic.Read(1);
            MockSchoolRepository.Verify(r => r.Read(1), Times.Once());
        }

        [Test]
        public void ReadDoesntExistTest()
        {
            try
            {
                var school = logic.Read(33);
            }
            catch (Exception ex) { }

            MockSchoolRepository.Verify(r => r.Read(3), Times.Never());
        }
    }
}
