using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("SchoolDatabaseMemory");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=SchoolDatabase;Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().ToTable("Persons");
            //modelBuilder.Entity<Classroom>().ToTable("Classrooms");

            modelBuilder.Entity<Person>()
                        .HasKey(p => p.PersonId);

            modelBuilder.Entity<Person>()
                        .Property(p => p.PersonId)
                        .UseIdentityColumn();

            modelBuilder.Entity<Person>()
                        .Property(p => p.FirstName)
                        .HasMaxLength(30)
                        .IsRequired();

            modelBuilder.Entity<Classroom>()
                        .HasMany(c => c.Students)
                        .WithOne(s => s.Classroom);

            modelBuilder.Entity<Classroom>()
                        .HasOne(c => c.Teacher)
                        .WithOne(t => t.Classroom);

            base.OnModelCreating(modelBuilder);
        }
    }
}
