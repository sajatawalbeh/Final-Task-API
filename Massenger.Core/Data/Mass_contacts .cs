using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Massenger.Core.Data
{
    public class Mass_contacts
    {
        [Key]
        public int id { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string first_Name { get; set; }
        public string last_Name { get; set; }
        public ICollection<Mass_user_contact> Mass_user_contact { get; set; }
    }
}
