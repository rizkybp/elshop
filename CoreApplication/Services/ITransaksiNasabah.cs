using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;
using CoreApplication.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CoreApplication.Services
{
    public interface ITransaksiNasabah : IAsyncBaseService<TransaksiNasabah>
    {
        Task<TransaksiNasabah> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<TransaksiNasabah> AddAsync(TransaksiNasabah entity, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TransaksiNasabah>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<bool> UpdateAsync(TransaksiNasabah entity, CancellationToken cancellationToken = default);
        Task<bool> DeleteAsync(TransaksiNasabah entity, CancellationToken cancellationToken = default);
      //  Task<int> CountAsync(ISpecification<TransaksiNasabah> spec, CancellationToken cancellationToken = default);
        //Task<IReadOnlyList<TransaksiNasabah>> ListAsync(ISpecification<TransaksiNasabah> spec, CancellationToken cancellationToken = default);
    }
}
