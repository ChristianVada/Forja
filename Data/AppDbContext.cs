using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.Emit;
using Forja.Entities;
using Microsoft.EntityFrameworkCore;

namespace Forja.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Anel> Anel_do_poder { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
