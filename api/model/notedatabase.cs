using System;
using Microsoft.EntityFrameworkCore;

namespace sample
{
    public class notedatabase : DbContext
    {
        public DbSet<mynotes> notes {get; set;}
    
    
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=notesDB1;Trusted_Connection=True;");
        }

    }

}