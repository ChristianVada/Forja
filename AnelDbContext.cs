using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2
{
    public class AnelDbContext : DbContext
    {
        public AnelDbContext(DbContextOptions<AnelDbContext> options) : base(options) { }
        public DbSet<AnelEntity> Aneis { get; set; }
    }
}
