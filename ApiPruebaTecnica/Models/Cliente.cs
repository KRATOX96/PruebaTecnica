using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaTecnica.Models
{
	[Table("Cliente")]

	public class Cliente 
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Contraseña { get; set; }
		public bool Estado { get; set; }	

		public int PersonaId { get; set; }
	}
}
