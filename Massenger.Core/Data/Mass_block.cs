using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Massenger.Core.Data
{
   public  class Mass_block
    {
        [Key]
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Mass_users users { get; set; }
        public int participants_id { get; set; }
        [ForeignKey("participants_id")]
        public virtual Mass_participants participants { get; set; }

    }
}
