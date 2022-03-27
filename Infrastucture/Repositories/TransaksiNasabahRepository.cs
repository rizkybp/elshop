using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreApplication.Entities;
using CoreApplication.Repositories;

namespace Infrastucture.Repositories
{
    public class TransaksiNasabahRepository : AsyncRepository<TransaksiNasabah> , ITransaksiNasabahRepository
    {
        public TransaksiNasabahRepository(AppDbContext context) : base(context) {
          

        }
        private AppDbContext MyDbContext
        {

            get { return Context as AppDbContext; }
            
        }

        

    }
}
