using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models.DTO
{
	public class ClienteUpdateDTO
	{
		[Required]
		public int Id { get; set; }

		public String Nombre { get; set; }

		public string Direccion { get; set; }

		public string Telefono { get; set; }
		public string Contraseña { get; set; }
		public bool Estado { get; set; }

		[Required]
		public int PersonaId { get; set; }
		public string Genero { get; set; }
		public string Identificacion { get; set; }

	}
}
