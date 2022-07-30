using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Massenger.Core.Data
{
    public class Mass_category
    {

        [Key]
        public int categoryid { get; set; }
        public string categoryName { get; set; }
        public ICollection<Mass_Service> Mass_Service { get; set; }
    }
}
