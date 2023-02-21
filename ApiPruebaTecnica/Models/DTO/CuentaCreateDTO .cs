using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models.DTO
{
	public class CuentaCreateDTO
	{
		public int NumeroCuenta { get; set; }

		public string TipoCuenta { get; set; }
		public bool SaldoInicial { get; set; }

		public int ClienteId { get; set; }

	}
}
