using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Massenger.Core.Data
{
    public class Mass_contry
    {

        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Mass_users> Mass_users { get; set; }

    }
}
