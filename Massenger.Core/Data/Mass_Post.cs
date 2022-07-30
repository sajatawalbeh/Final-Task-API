using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Massenger.Core.Data
{
    public class Mass_Post
    {

        [Key]
        public int id { get; set; }
        public string content { get; set; }
        public string imageName { get; set; }
        //public int likes { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Mass_users users { get; set; }
         public ICollection<Mass_Like> Mass_Like { get; set; }
    }


    }

