using ApiPruebaTecnica.Models;
using ApiPruebaTecnica.Models.DTO;
using AutoMapper;

namespace ApiPruebaTecnica
{
	public class MappingConfig: Profile
	{
		public MappingConfig()
		{
			CreateMap<Cuenta, CuentaDTO>().ReverseMap();
			CreateMap<Cuenta, CuentaCreateDTO>().ReverseMap();
			CreateMap<Cuenta, CuentaUpdateDTO>().ReverseMap();

			CreateMap<Movimiento, MovimientoDTO>().ReverseMap();
			CreateMap<Movimiento, MovimientoCreateDTO>().ReverseMap();
			CreateMap<Movimiento, MovimientoUpdateDTO>().ReverseMap();


			CreateMap<Cliente, ClienteCreateDTO>().ReverseMap();
			CreateMap<Cliente, ClienteUpdateDTO>().ReverseMap();
			CreateMap<Cliente, ClienteDTO>().ReverseMap();

			CreateMap<ClienteCreateDTO, Persona>().ReverseMap();
			CreateMap<ClienteDTO, Persona>().ReverseMap();
			CreateMap<ClienteUpdateDTO, Persona>().ReverseMap();

		}
	}
}
