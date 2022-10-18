using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using ENOMVG_HFT_2022231.Models;

namespace ENOMVG_HFT_2022231.Repository
{
    public class SchollingDbContext : DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public SchollingDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;
                //AttachDbFilename=|DataDirectory|\SchoolingDbInM.mdf;Integrated Security=True;MultipleActiveResultSets=true";

                builder
                    .UseInMemoryDatabase("SchoolingDb")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(Student => Student
                .HasOne<School>()   //egy diákhoz van 1 suli
                .WithMany()         //egy suli több diákhoz is tartozhat
                .HasForeignKey(Student => Student.SchoolId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Teacher>(Teacher => Teacher
                .HasOne<School>()
                .WithMany()
                .HasForeignKey(Teacher => Teacher.SchoolId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<School>().HasData(new School[]
            {
                new School(1, "Soproni Széchenyi István Gimnázium", "Gimnázium"),
                new School(2, "Berzsenyi Dániel Evangélikus (Líceum) Gimnázium és Kollégium", "Gimnázium"),
                new School(3, "Soproni Deák Téri Általános Iskola", "Általános")
            });

            modelBuilder.Entity<Teacher>().HasData(new Teacher[]
            {
                new Teacher(1, "Bejóné Zsoldos Gyöngyi", "tanító",3),
                new Teacher(2, "Márti néni", "tanító",1),
                new Teacher(3, "Lang", "fizika",3),
                new Teacher(4, "Jakab", "német", 1),
                new Teacher(5, "Kovács Antal József", "történelem", 2),
                new Teacher(6, "Kiss Egér", "Földrajz", 2)
            });

            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student(1, "Bejó Mátyás", 16, 1, 5),
                new Student(2, "Szojka Áron", 17, 1, 3.24),
                new Student(3, "Hargitai Benke", 17, 2, 4.76),
                new Student(4, "Dejó Dorka", 13, 3, 4.453)
            });
        } 
    }
}
