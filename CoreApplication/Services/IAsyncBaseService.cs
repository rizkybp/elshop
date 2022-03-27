using System;
using System.Collections.Generic;
using System.Text;
using CoreApplication.Entities;

namespace CoreApplication.Services
{
    public interface IAsyncBaseService<T> where T : BaseEntity
    {
        void AddError(string errorMessage);
        void ClearErrors();
        bool ServiceState { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
