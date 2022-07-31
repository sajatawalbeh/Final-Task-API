using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Massenger.Core.Data
{
    public class Mass_user_contact
    {
        [Key]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Mass_users users { get; set; }

        public int contacts_id { get; set; }
        [ForeignKey("contacts_id")]
        public virtual Mass_contacts contacts { get; set; }
    }
}
