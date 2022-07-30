using Massenger.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Repository
{
    public interface IMass_ContactRepository
    {
        public List<Mass_contacts> Getallcontact();

        public bool Createcontact(Mass_contacts contact);

        public bool Deletecontact(int? id);

        public bool Updatecontact(Mass_contacts contact);
    }
}
