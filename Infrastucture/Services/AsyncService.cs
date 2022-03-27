using System;
using System.Collections.Generic;
using System.Text;
using CoreApplication.Services;
using CoreApplication.Entities;
using CoreApplication;

namespace Infrastucture.Services
{
    public class AsyncService<T> : IAsyncBaseService<T> where T : BaseEntity
    {
        protected readonly IUnitOfWork _unitOfWork;
        
        private readonly List<string> _errors = new List<string>();

        public AsyncService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IUnitOfWork UnitOfWork => _unitOfWork;

        public IReadOnlyList<string> Errors => _errors;

        public void AddError(string errorMessage)
        {
            if (_errors.Contains(errorMessage)) return;
            _errors.Add(errorMessage);
        }

        public void ClearErrors()
        {
            _errors.Clear();
        }

        public bool ServiceState => _errors.Count == 0;
    }
}
