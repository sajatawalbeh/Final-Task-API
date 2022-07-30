using Massenger.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Service
{
    public interface IMass_User_contactService
    {
        public List<Mass_user_contact> Getallusercontact();

        public bool Createusercontact(Mass_user_contact usercontact);

        public bool Deleteusercontact(int? id);

        public bool Updateusercontact(Mass_user_contact usercontact);
    }
}
