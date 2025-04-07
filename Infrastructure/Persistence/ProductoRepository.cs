using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence
{
    public class ProductoRepository : IProductoRepository
    {

        private readonly IRepository<Producto> repository;

        public ProductoRepository(IRepository<Producto> repository)
        {
            this.repository = repository;
        }

        public async Task Create(Producto objeto)
        {
            await repository.Insert(objeto);
        }

        public async Task Delete(Producto objeto)
        {
            await repository.Delete(objeto);
        }

        public async Task<List<Producto>> GetAll()
        {
            return await repository.GetAll();
        }

        public async Task<Producto?> GetId(int objeto)
        {
            return await repository.GetById(objeto);

        }

        public async Task Update(Producto objeto)
        {
            await repository.Update(objeto);
        }
    }
}
