using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 


namespace mission_8.Models
{
    public class TaskInfoContext: DbContext
    {
        public TaskInfoContext(DbContextOptions<TaskInfoContext> options) : base(options)
        {

        }
        public DbSet<TaskResponse> responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //mb.Entity<TaskResponse>().HasData();
        }
    }
}

