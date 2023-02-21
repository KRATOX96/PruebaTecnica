using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models.DTO
{
	public class ClienteCreateDTO
	{
		[Required]

		public String Nombre { get; set; }	

		public string Direccion { get; set; }

		public string Telefono { get; set; }
		public string Contraseña { get; set; }
		public bool Estado { get; set; }
		public int PersonaId { get; set; }
		public string Identificacion { get; set; }

		public string Genero { get; set; }


	}
}
