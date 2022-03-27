using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using CoreApplication;
using CoreApplication.Entities;
using CoreApplication.Services;


namespace Infrastucture.Services
{
    public class NasabahService : AsyncService<Nasabah> , INasabahService
    {


        public NasabahService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async  Task<Nasabah> AddAsync(Nasabah entity, CancellationToken cancellationToken = default)
        {
           await _unitOfWork.nasabahRepository.AddAsync(entity, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return entity;
        }



       

        //public Task<int> CountAsync(ISpecification<Nasabah> spec, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        public  async Task<bool> DeleteAsync(Nasabah entity, CancellationToken cancellationToken = default)
        {
            _unitOfWork.nasabahRepository.DeleteAsync(entity);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public async Task<Nasabah> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.nasabahRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<IReadOnlyList<Nasabah>> ListAllAsync(CancellationToken cancellationToken = default)
        {
           return await _unitOfWork.nasabahRepository.ListAllAsync(cancellationToken);
        }

        //public Task<IReadOnlyList<Nasabah>> ListAsync(ISpecification<Nasabah> spec, CancellationToken cancellationToken = default)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> UpdateAsync(Nasabah entity, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.nasabahRepository.ReplaceAsync(entity, entity.id);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
