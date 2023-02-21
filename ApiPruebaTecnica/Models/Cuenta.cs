using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaTecnica.Models
{
	public class Cuenta
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }	
		public int NumeroCuenta { get; set; }

		public string TipoCuenta { get; set; }
		public bool SaldoInicial { get; set; }	

		public int ClienteId { get; set; }
	}
}
