using System;
using System.Collections.Generic;
using System.Text;
using CoreApplication.Entities;

using Infrastucture.Services;
using CoreApplication.Services;
using System.Threading.Tasks;
using System.Threading;
using CoreApplication;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using CoreApplication.Spesification;

namespace Infrastucture.Services
{
    public class TransaksiNasabahService : AsyncService<TransaksiNasabah>, ITransaksiNasabah 
    {
        public TransaksiNasabahService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public async Task<TransaksiNasabah> AddAsync(TransaksiNasabah entity, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.transaksiNasabahRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public  async Task<bool> DeleteAsync(TransaksiNasabah entity, CancellationToken cancellationToken = default)
        {
             _unitOfWork.transaksiNasabahRepository.DeleteAsync(entity, cancellationToken);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<TransaksiNasabah> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            //return await _unitOfWork.transaksiNasabahRepository.GetByIdAsync(id, cancellationToken);

            var spek = new TransaksiNasabahSpeck();
            
            return await _unitOfWork.transaksiNasabahRepository.FirstOrDefaultAsync(spek.GetById(id), cancellationToken);
        }

        public async Task<IReadOnlyList<TransaksiNasabah>> ListAllAsync(CancellationToken cancellationToken = default)
         {
            var spek = new TransaksiNasabahSpeck();
            return await _unitOfWork.transaksiNasabahRepository.ListAsync(spek.IncludeNasabah(), cancellationToken);
        }

        public async Task<bool> UpdateAsync(TransaksiNasabah entity, CancellationToken cancellationToken = default)
        {
           await _unitOfWork.transaksiNasabahRepository.ReplaceAsync(entity, entity.Id);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
