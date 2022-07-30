using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Massenger.Core.Data
{
   public  class Mass_conversation
    {
        [Key]
        public int conversationid { get; set; }
        public string title { get; set; }
        public ICollection<Mass_participants> Mass_participants { get; set; }
        public ICollection<Mass_user_contact> Mass_user_contact { get; set; }
    }
}
