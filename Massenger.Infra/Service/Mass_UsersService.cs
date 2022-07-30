using Massenger.Core.Data;
using Massenger.Core.DTO;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
    public class Mass_UsersService : IMass_UsersService
    {
        private readonly IMass_UsersRepository repo;
        public Mass_UsersService(IMass_UsersRepository repo)
        {
            this.repo = repo;
        }
        public bool Createuser(Mass_users user)
        {
            return repo.Createuser(user);
        }

        public bool Deleteuser(int? id)
        {
            return repo.Deleteuser(id);
        }

        public List<Mass_users> Getalluser()
        {
            return repo.Getalluser();
        }

        public bool Updateuser(Mass_users user)
        {
            return repo.Updateuser(user);
        }
        public List<Mass_users> InsertUserList(Mass_users[] user)
        {
            return repo.InsertUserList(user);
        }
        public string Block(BlockDTO block)
        {
            return repo.Block(block);
        }
    }
}
