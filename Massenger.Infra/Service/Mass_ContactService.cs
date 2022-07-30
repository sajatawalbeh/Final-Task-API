using Massenger.Core.Data;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
    public class Mass_ContactService : IMass_ContactService
    {
        private readonly IMass_ContactRepository repo;
        public Mass_ContactService(IMass_ContactRepository repo)
        {
            this.repo = repo;
        }
        public bool Createcontact(Mass_contacts contact)
        {
            return repo.Createcontact(contact);
        }

        public bool Deletecontact(int? id)
        {
            return repo.Deletecontact(id);
        }

        public List<Mass_contacts> Getallcontact()
        {
            return repo.Getallcontact();
        }

        public bool Updatecontact(Mass_contacts contact)
        {
            return repo.Updatecontact(contact);
        }
    }
}
