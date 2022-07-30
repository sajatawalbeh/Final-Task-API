using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Massenger.Core.Data
{
   public  class Mass_Login
    {
        [Key]
        public int ID { get; set; }
        public string username { get; set; }
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$",
        //    ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, " +
        //    "one lowercase letter,one digit and one special character.")]
        public string password { get; set; }
        public string rolename { get; set; }
      
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Mass_users user { get; set; }


    }
}
