using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CoreApplication;
using CoreApplication.Repositories;
using Infrastucture.Repositories;

namespace Infrastucture
{
    public class UnitOfWork : IUnitOfWork
    {
       
        private readonly AppDbContext _context;
        private ITransaksiNasabahRepository transaksiNasabahRepository;
        private INasabahRepository nasabahRepository;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
       public INasabahRepository NasabahRepository => nasabahRepository ?? new NasabahRepository(_context);

       public ITransaksiNasabahRepository TransaksiNasabahRepository => transaksiNasabahRepository ?? new TransaksiNasabahRepository(_context);

         INasabahRepository IUnitOfWork.nasabahRepository => nasabahRepository ?? new NasabahRepository(_context);

        ITransaksiNasabahRepository IUnitOfWork.transaksiNasabahRepository => transaksiNasabahRepository ?? new TransaksiNasabahRepository(_context);

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
