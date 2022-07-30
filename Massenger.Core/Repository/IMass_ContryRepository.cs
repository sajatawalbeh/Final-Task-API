using Massenger.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Repository
{
   public interface IMass_ContryRepository
    {
        public List<Mass_contry> GetallCountry();

        public bool CreateCountry(Mass_contry Country);

        public bool DeleteCountry(int? id);

        public bool UpdateCountry(Mass_contry Country);
        public List<string> UserAndCountry(int id);
    }
}
