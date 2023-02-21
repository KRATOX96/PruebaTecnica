using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaTecnica.Models
{
	public class Persona
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Genero { get; set; }

		public int Edad { get; set; }
		public string Identificacion { get; set; }

		public string Direccion { get; set; }

		public int telefono { get; set; }
	}
}
