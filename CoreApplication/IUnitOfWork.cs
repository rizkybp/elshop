using System;
using System.Collections.Generic;
using System.Text;
using CoreApplication.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace CoreApplication
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
        INasabahRepository nasabahRepository { get; }
        ITransaksiNasabahRepository transaksiNasabahRepository { get; }


    }
}
