using Microsoft.EntityFrameworkCore;
using MyBackend.Models;
using System.Collections.Generic;

namespace MyBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; } = null!;

    }
}
