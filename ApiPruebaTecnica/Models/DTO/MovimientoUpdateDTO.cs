using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models.DTO
{
	public class MovimientoUpdateDTO
	{
		[Required]
		public int Id { get; set; }

		public string TipoMovimiento { get; set; }
		public string ValorMovimiento { get; set; }

		public int Estado { get; set; }

		public DateTime Fecha { get; set; }

		public int Saldo { get; set; }

	}
}
