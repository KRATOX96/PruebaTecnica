using ApiPruebaTecnica.Models;
using System.Linq.Expressions;

namespace ApiPruebaTecnica.Repository.IRepository
{
	public interface IClienteRepository
	{
		Task <List<Cliente>> GetAll(Expression<Func<Cliente>> filter = null);
		Task<List<Cliente>> Get(Expression<Func<Cliente>> filter = null);
		Task Create(Cliente entity);
		Task Remove(Cliente entity);
		Task Save();
	}
}
