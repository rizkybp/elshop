using Ardalis.Specification;
using CoreApplication.Entities;
using CoreApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace Infrastucture.Repositories
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly DbContext Context;

        public AsyncRepository(AppDbContext context)
        {
            Context = context;
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
             await Context.Set<T>().AddAsync(entity);
          

            return entity;
        }

        public async Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var spesicationResult = ApplySpecification(spec);
            return await spesicationResult.CountAsync(cancellationToken);
        }

        public void  DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            Context.Set<T>().Remove(entity);
        }

        public async Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await Context.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { int.Parse(id) };
            return await Context.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = Context.Set<T>().AsQueryable();
            return await query.ToListAsync(cancellationToken);

        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync(cancellationToken);
        }

        public async Task ReplaceAsync(T entity, int id, CancellationToken cancellationToken = default)
        {
            Context.Database.SetCommandTimeout(int.MaxValue);
            T originalData = await Context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            if (cancellationToken.IsCancellationRequested)
                return;

            if (originalData == null)
                throw new Exception($"{nameof(T)} with id {id} not found.");

           

            EntityEntry<T> entry = Context.Entry<T>(originalData);
            entry.CurrentValues.SetValues(entity);
            entry.State = EntityState.Modified;
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        protected IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            if (spec == null)
                return Context.Set<T>().AsQueryable();

            var evaluator = new SpecificationEvaluator<T>();
            var queryResult = evaluator.GetQuery(Context.Set<T>().AsQueryable(), spec);

            // queryResult = ApplySorting(sorting, queryResult);

            return queryResult;
        }
    }
}
