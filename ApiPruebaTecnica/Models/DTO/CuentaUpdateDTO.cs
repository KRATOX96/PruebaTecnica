using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models.DTO
{
	public class CuentaUpdateDTO
	{
		[Required]
		public int Id { get; set; }

		public int NumeroCuenta { get; set; }

		public string TipoCuenta { get; set; }
		public bool SaldoInicial { get; set; }

		public int ClienteId { get; set; }

	}
}
