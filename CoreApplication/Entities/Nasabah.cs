using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CoreApplication.Entities
{
    public class Nasabah : BaseEntity
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
