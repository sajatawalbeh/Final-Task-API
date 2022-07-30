using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Massenger.Core.Data
{
    public class Mass_users
    {
        [Key]
        public int id { get; set; }
        public string phone { get; set; }
       
        public string first_Name { get; set; }
        
        public int is_blocked { get; set; }
        public int country_id { get; set; }
        [ForeignKey("country_id")]
        public string Email { get; set; }
        public virtual Mass_contry country { get; set; }
        public ICollection<Mass_participants> Mass_participants { get; set; }
        public ICollection<Mass_block> Mass_block { get; set; }
        public ICollection<Mass_user_contact> Mass_user_contact { get; set; }
        public ICollection<Mass_Post> Mass_Post { get; set; }

        public ICollection<Mass_Like> Mass_Like { get; set; }
      


        
    }
}
