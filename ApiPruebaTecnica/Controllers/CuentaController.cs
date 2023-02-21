using ApiPruebaTecnica.Data;
using ApiPruebaTecnica.Models;
using ApiPruebaTecnica.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ApiPruebaTecnica.Controllers
{
		[Route("api/Cuenta")]
	[ApiController]
	public class CuentaController : ControllerBase
	{
		private readonly ApplicationDbContext _db;
		private readonly IMapper _mapper;

		public CuentaController(ApplicationDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CuentaDTO>>> GetCuentas()
		{
			return Ok(await _db.Cuentas.ToListAsync());
		}

		[HttpGet("{id:int}", Name = "GetCuenta")]
		public async Task<ActionResult<CuentaDTO>> GetCuenta(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var cuenta = await _db.Cuentas.FirstOrDefaultAsync(u => u.Id == id);
			if (cuenta == null)
			{
				return NotFound();
			}
			return Ok(cuenta);


		}

		[HttpPost]
		public async Task<ActionResult<CuentaDTO>> CreateCuenta([FromBody] CuentaCreateDTO createDTO)
		{
			if (createDTO == null)
			{
				return  BadRequest(createDTO);
			}

			Cuenta model = _mapper.Map<Cuenta>(createDTO);
			await _db.Cuentas.AddAsync(model);
			await _db.SaveChangesAsync();

			return CreatedAtRoute("GetCuenta", new { id = model.Id }, createDTO);
			//return Ok(cuentaDTO);
		}

		[HttpDelete("{id:int}", Name = "DeleteCuenta")]
		public async Task <IActionResult> DeleteCuenta(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var cuenta = _db.Cuentas.FirstOrDefault(u => u.Id == id);

			if (cuenta == null)
			{
				return NotFound();
			}

			_db.Cuentas.Remove(cuenta);
			await _db.SaveChangesAsync();
			return NoContent();

		}

		[HttpPut("{id:int}", Name = "UpdateCuenta")]
		public async Task <IActionResult> UpdateCuenta(int id, [FromBody] CuentaUpdateDTO createDTO)
		{
			if (createDTO == null || id != createDTO.Id)
			{
				return BadRequest();
			}


			Cuenta model = _mapper.Map<Cuenta>(createDTO);
			_db.Cuentas.Update(model);
			await _db.SaveChangesAsync();
			return NoContent();

		}
	}
}
