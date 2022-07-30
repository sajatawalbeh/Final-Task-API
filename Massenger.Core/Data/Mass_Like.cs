using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Massenger.Core.Data
{
   public  class Mass_Like
    {

        [Key]
        public int id { get; set; }
        public int Post_id { get; set; }
        [ForeignKey("post_id")]
        public virtual Mass_Post post { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Mass_users users { get; set; }
      
    }
}
