using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;
using CoreApplication.Entities;

namespace CoreApplication.Spesification
{
    public class TransaksiNasabahSpeck :Specification<TransaksiNasabah>
    {
      public TransaksiNasabahSpeck IncludeNasabah()
        {
            Query.Include(p => p.Nasabah);
            return this;
        }

        public TransaksiNasabahSpeck GetById(string id)
        {
            Query.Include(p => p.Nasabah);

            Query.Where(p => p.Id == int.Parse(id));
            return this;
        }
    }
}
