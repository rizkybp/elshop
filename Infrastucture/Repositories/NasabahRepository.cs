using System;
using System.Collections.Generic;
using System.Text;
using CoreApplication.Entities;
using CoreApplication.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Infrastucture.Repositories
{
    public class NasabahRepository : AsyncRepository<Nasabah> , INasabahRepository
    {
        public NasabahRepository(AppDbContext context) : base(context) { }
        private AppDbContext MyDbContext
        {
            get { return Context as AppDbContext; }
        }
    }
}
