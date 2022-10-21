﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENOMVG_HFT_2022231.Repository;
using ENOMVG_HFT_2022231.Models;

namespace ENOMVG_HFT_2022231.Logic
{
    internal class TeacherLogic
    {
        IRepository<Teacher> repository;

        public TeacherLogic(IRepository<Teacher> _tchrepo)
        {
            repository = _tchrepo;
        }

        public void Create(Teacher item)
        {
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Teacher Read(int id)
        {
            var teacher = this.repository.Read(id);
            if (teacher == null)
            {
                throw new ArgumentException("Movie not exists");
            }

            return teacher;
        }

        public IQueryable<Teacher> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Teacher teacher)
        {
            this.repository.Update(teacher);
        }
    }
}