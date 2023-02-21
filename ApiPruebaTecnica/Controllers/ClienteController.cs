using ApiPruebaTecnica.Data;
using ApiPruebaTecnica.Models;
using ApiPruebaTecnica.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Controllers
{
	[Route("api/Cliente")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public ClienteController(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
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
		public ActionResult<ClienteDTO> CreateCliente([FromBody] ClienteCreateDTO clienteDTO)
		{
			if (clienteDTO == null)
			{
				return  BadRequest(clienteDTO);
			}


				//Cliente model = new()
				//{
				//	Contraseña = clienteDTO.Contraseña,
				//	Estado = clienteDTO.Estado,
				//	PersonaId = clienteDTO.PersonaId
				//};

			Cliente modelCliente = _mapper.Map<Cliente>(clienteDTO);
			Persona modelPersona = _mapper.Map<Persona>(clienteDTO);
			 _db.Personas.Add(modelPersona);
			 _db.SaveChanges();
			modelCliente.PersonaId = modelPersona.Id;
			 _db.Clientes.Add(modelCliente);
			 _db.SaveChanges();

			return CreatedAtRoute("GetCliente", new { id = modelCliente.Id }, clienteDTO);
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


			Cliente modelCliente = _mapper.Map<Cliente>(clienteDTO);
			Persona modelPersona = _mapper.Map<Persona>(clienteDTO);
			modelCliente.PersonaId = modelPersona.Id;


			_db.Clientes.Update(modelCliente);
			_db.Personas.Update(modelPersona);
			await _db.SaveChangesAsync();
			return NoContent();

		}
	}
}
