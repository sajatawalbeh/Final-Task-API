using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Massenger.Core.Data
{
    public class Mass_participants
    {
        [Key]
        public int participantsid { get; set; }

        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Mass_users users { get; set; }

        public int conversation_id { get; set; }
        [ForeignKey("conversation_id")]
        public virtual Mass_conversation conversation { get; set; }
        public string type { get; set; }
        public ICollection<Mass_block> Mass_block { get; set; }


    }
}
