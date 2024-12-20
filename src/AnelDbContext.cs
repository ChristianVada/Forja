using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Forja.src
{
    public class AnelDbContext : DbContext
    {
        public AnelDbContext(DbContextOptions<AnelDbContext> options) : base(options) { }
        public DbSet<AnelEntity> Aneis { get; set; }
    }
}
