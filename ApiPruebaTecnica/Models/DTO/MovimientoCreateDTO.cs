using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models.DTO
{
	public class MovimientoCreateDTO
	{
		[Required]
		public string TipoMovimiento { get; set; }
		public string ValorMovimiento { get; set; }

		public int Estado { get; set; }

		public DateTime Fecha { get; set; }

		public int Saldo { get; set; }

	}
}
