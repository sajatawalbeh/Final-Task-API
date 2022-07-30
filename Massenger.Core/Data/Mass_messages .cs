using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Massenger.Core.Data
{
   public class Mass_messages
    {
        [Key]
        public int id { get; set; }
        public string message { get; set; }
        public DateTime created_at { get; set; }
        public int sender_id { get; set; }
        [ForeignKey("sender_id")]
        public virtual Mass_users users { get; set; }

        public int conversation_id { get; set; }
        [ForeignKey("conversation_id")]
        public virtual Mass_conversation conversation { get; set; }

    }
}
