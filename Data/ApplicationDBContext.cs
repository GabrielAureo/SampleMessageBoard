using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleMessageBoard.Models;

namespace SampleMessageBoard.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Thread> Threads { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Post> Posts { get; set; }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
