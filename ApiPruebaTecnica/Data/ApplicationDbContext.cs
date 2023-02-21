using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Data
{
	public class ApplicationDbContext: DbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}

		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<Cuenta> Cuentas { get; set; }
		public DbSet<Movimiento> Movimientos { get; set; }
		public DbSet<Persona> Personas { get; set; }
	}
}
