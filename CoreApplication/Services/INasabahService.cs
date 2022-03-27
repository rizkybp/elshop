using System;
using System.Collections.Generic;
using System.Text;
using CoreApplication.Entities;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.Specification;

namespace CoreApplication.Services
{
    public interface INasabahService : IAsyncBaseService<Nasabah>
    {
        Task<Nasabah> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<Nasabah> AddAsync(Nasabah entity, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<Nasabah>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(Nasabah entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(Nasabah entity, CancellationToken cancellationToken = default);
       // Task<int> CountAsync(ISpecification<Nasabah> spec, CancellationToken cancellationToken = default);
       // Task<IReadOnlyList<Nasabah>> ListAsync(ISpecification<Nasabah> spec,CancellationToken cancellationToken = default);



    }
}
