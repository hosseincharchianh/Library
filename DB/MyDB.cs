using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using databaseExercise.Entities;
using Microsoft.EntityFrameworkCore;

namespace databaseExercise.DB
{
    public class MyDB : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=library.db");
        }
}
}