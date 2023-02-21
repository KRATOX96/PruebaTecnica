using ApiPruebaTecnica.Data;
using ApiPruebaTecnica.Models;
using ApiPruebaTecnica.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Controllers
{

	[Route("api/Movimiento")]
	[ApiController]
	public class MovimientoController : ControllerBase
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public MovimientoController(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<MovimientoDTO>>> GetMovimientos()
		{
			return Ok(await _db.Movimientos.ToListAsync());
		}

		[HttpGet("{id:int}", Name = "GetMovimiento")]
		public async Task<ActionResult<MovimientoDTO>> GetMovimiento(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var movimiento = await _db.Movimientos.FirstOrDefaultAsync(u => u.Id == id);
			if (movimiento == null)
			{
				return NotFound();
			}
			return Ok(movimiento);


		}

		[HttpPost]
		public async Task<ActionResult<MovimientoDTO>> CreateMovimiento([FromBody] MovimientoCreateDTO createDTO)
		{

			if (createDTO == null)
			{
				return BadRequest(createDTO);
			}

			Movimiento model = _mapper.Map<Movimiento>(createDTO);
			await _db.Movimientos.AddAsync(model);
			await _db.SaveChangesAsync();

			return CreatedAtRoute("GetMovimiento", new { id = model.Id }, createDTO);
			//return Ok(movimientoDTO);
		}

		[HttpDelete("{id:int}", Name = "DeleteMovimiento")]
		public async Task<IActionResult> DeleteMovimiento(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var movimiento = _db.Movimientos.FirstOrDefault(u => u.Id == id);

			if (movimiento == null)
			{
				return NotFound();
			}

			_db.Movimientos.Remove(movimiento);
			await _db.SaveChangesAsync();
			return NoContent();

		}

		[HttpPut("{id:int}", Name = "UpdateMovimiento")]
		public async Task<IActionResult> UpdateMovimiento(int id, [FromBody] MovimientoUpdateDTO createDTO)
		{
			if (createDTO == null || id != createDTO.Id)
			{
				return BadRequest();
			}



			Movimiento model = _mapper.Map<Movimiento>(createDTO);

			_db.Movimientos.Update(model);
			await _db.SaveChangesAsync();
			return NoContent();

		}
}
}
