using Microsoft.EntityFrameworkCore;
using RocketFin.Api.Persistance.Model;

namespace RocketFin.Api.Persistance.Context
{
	public class RocketFinDbContext : DbContext
	{

		public virtual DbSet<LedgerDataModel> Ledgers { get; set; }

		public RocketFinDbContext(DbContextOptions<RocketFinDbContext> options) : base(options)
		{
		}
	}
}
