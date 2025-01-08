using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.DataAccess
{
    public class TodoDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set;}
        public DbSet<Author> Author { get; set;}

        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = @"Server=(localdb)\MSSQLLocaldb;Database=MyTodoDb;Trusted_Connection=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author { Id = 1, FullName = "Saman Ekanayake", AddressNo = "100", Street = "Street 1", City = "Balangoda", JobRole = "Developer" },
                new Author { Id = 2, FullName = "Janaka Haren", AddressNo = "2/E", Street = "Main Street", City = "Matara", JobRole = "System Engineer" },
                new Author { Id = 3, FullName = "Aruna Shantha", AddressNo = "100/2", Street = "Flower Street", City = "Matara", JobRole = "Developer" },
                new Author { Id = 4, FullName = "Piyal Perera", AddressNo = "300/a", Street = "Street 1", City = "Colombo", JobRole = "QA" },
            });
            modelBuilder.Entity<Todo>().HasData(new Todo
            {
                Id = 1,
                Title = "Go to Bank",
                Description = "Need to go bank for some deposits",
                Created = DateTime.Now,
                Due = DateTime.Now.AddDays(5),
                Status = TodoStatus.New,
                AuthorId = 1
            });
        }
    }
}
