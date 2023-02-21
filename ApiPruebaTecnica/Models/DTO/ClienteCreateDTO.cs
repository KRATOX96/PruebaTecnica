using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models.DTO
{
	public class ClienteCreateDTO
	{
		[Required]
		public string Contraseña { get; set; }
		public bool Estado { get; set; }
		public int PersonaId { get; set; }

	}
}
