using System;
using Microsoft.EntityFrameworkCore;
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
                string conn = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = |DataDirectory|\schooling.mdf; Integrated Security = True; MultipleActiveResultSets = True";
                builder.UseLazyLoadingProxies();
                builder.UseSqlServer(conn);
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
                new School("Soproni Széchenyi István Gimnázium", "Gimnázium",1),
                new School("Berzsenyi Dániel Evangélikus (Líceum) Gimnázium és Kollégium", "Gimnázium",2),
                new School("Soproni Deák Téri Általános Iskola", "Általános",3)
            });

            modelBuilder.Entity<Teacher>().HasData(new Teacher[]
            {
                new Teacher("Bejóné Zsoldos Gyöngyi", "tanító"),
                new Teacher("Márti néni", "tanító"),
                new Teacher("Lang", "fizika"),
                new Teacher("Jakab", "német"),
                new Teacher("Kovács Antal József", "történelem"),
                new Teacher("Kiss Egér", "Földrajz")
            });

            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student("Bejó Mátyás", 16, 0,1),
                new Student("Szojka Áron", 17, 0,2),
                new Student("Hargitai Benke", 17, 1,3),
                new Student("Dejó Dorka", 13,2,4)
            });
        } 
    }
}
