using Massenger.Core.Data;
using Massenger.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Service
{
   public  interface IMass_UsersService
    {
        public List<Mass_users> Getalluser();

        public bool Createuser(Mass_users user);

        public bool Deleteuser(int? id);

        public bool Updateuser(Mass_users user);
        public List<Mass_users> InsertUserList(Mass_users[] user);
        public string Block(BlockDTO block);

    }
}
