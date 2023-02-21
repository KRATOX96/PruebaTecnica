using ApiPruebaTecnica.Data;
using ApiPruebaTecnica.Models;
using ApiPruebaTecnica.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Controllers
{
	[Route("api/Cliente")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly ApplicationDbContext _db;

		public ClienteController(ApplicationDbContext db)
		{
			_db = db;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ClienteDTO>>> GetClientes()
		{
			return Ok(await _db.Clientes.ToListAsync());
		}

		[HttpGet("{id:int}", Name = "GetCliente")]
		public async Task<ActionResult<ClienteDTO>> GetCliente(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var cliente = await _db.Clientes.FirstOrDefaultAsync(u => u.Id == id);
			if (cliente == null)
			{
				return NotFound();
			}
			return Ok(cliente);


		}

		[HttpPost]
		public async Task<ActionResult<ClienteDTO>> CreateCliente([FromBody] ClienteCreateDTO clienteDTO)
		{
			if (clienteDTO == null)
			{
				return  BadRequest(clienteDTO);
			}
			Cliente model = new()
			{
				Contraseña = clienteDTO.Contraseña,
				Estado = clienteDTO.Estado,
				PersonaId = clienteDTO.PersonaId
			};
			await _db.Clientes.AddAsync(model);
			await _db.SaveChangesAsync();

			return CreatedAtRoute("GetCliente", new { id = model.Id }, clienteDTO);
			//return Ok(clienteDTO);
		}

		[HttpDelete("{id:int}", Name = "DeleteCliente")]
		public async Task <IActionResult> DeleteCliente(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var cliente = _db.Clientes.FirstOrDefault(u => u.Id == id);

			if (cliente == null)
			{
				return NotFound();
			}

			_db.Clientes.Remove(cliente);
			await _db.SaveChangesAsync();
			return NoContent();

		}

		[HttpPut("{id:int}", Name = "UpdateCliente")]
		public async Task <IActionResult> UpdateCliente(int id, [FromBody] ClienteUpdateDTO clienteDTO)
		{
			if (clienteDTO == null || id != clienteDTO.Id)
			{
				return BadRequest();
			}


			Cliente model = new()
			{
				Id = clienteDTO.Id,	
				Contraseña = clienteDTO.Contraseña,
				Estado = clienteDTO.Estado,
				PersonaId = clienteDTO.PersonaId
			};
			_db.Clientes.Update(model);
			await _db.SaveChangesAsync();
			return NoContent();

		}
	}
}
