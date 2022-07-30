using Massenger.Core.Data;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
    public class Mass_User_contactService : IMass_User_contactService
    {
        private readonly IMass_User_contactRepository repo;
        public Mass_User_contactService(IMass_User_contactRepository repo)
        {
            this.repo = repo;
        }
        public bool Createusercontact(Mass_user_contact usercontact)
        {
            return repo.Createusercontact(usercontact);
        }

        public bool Deleteusercontact(int? id)
        {
            return repo.Deleteusercontact(id);
        }

        public List<Mass_user_contact> Getallusercontact()
        {
            return repo.Getallusercontact();
        }

        public bool Updateusercontact(Mass_user_contact usercontact)
        {
            return repo.Updateusercontact(usercontact);
        }
    }
}
