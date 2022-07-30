using Massenger.Core.Data;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
    public class Mass_ContryService : IMass_ContryService
    {
        private readonly IMass_ContryRepository repo;
        public Mass_ContryService(IMass_ContryRepository repo)
        {
            this.repo = repo;
        }
        public bool CreateCountry(Mass_contry Country)
        {
            return repo.CreateCountry(Country);
        }

        public bool DeleteCountry(int? id)
        {
            return repo.DeleteCountry(id);
        }

        public List<Mass_contry> GetallCountry()
        {
            return repo.GetallCountry();
        }

        public bool UpdateCountry(Mass_contry Country)
        {
            return repo.UpdateCountry(Country);
        }

        public List<string> UserAndCountry(int id)
        {
            return repo.UserAndCountry(id);
        }
    }
}
