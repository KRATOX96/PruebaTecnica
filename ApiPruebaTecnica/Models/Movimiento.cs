using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaTecnica.Models
{
	public class Movimiento
	{

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }	
		public string TipoMovimiento { get; set; }
		public string ValorMovimiento { get; set; }	

		public int Estado { get; set; }

		public DateTime Fecha { get; set; }

		public int Saldo { get; set; }
	}
}
