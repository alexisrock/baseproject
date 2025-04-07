using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto?> GetId(int objeto);
        Task Create(Producto objeto);
        Task Delete(Producto objeto);
        Task Update(Producto objeto);
        Task<List<Producto>> GetAll();
    }
}
