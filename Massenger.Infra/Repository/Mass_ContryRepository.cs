using Dapper;
using Massenger.Core.Common;
using Massenger.Core.Data;
using Massenger.Core.DTO;
using Massenger.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Massenger.Infra.Repository
{
    public class Mass_ContryRepository : IMass_ContryRepository
    {
        private readonly IDbContext dbContext;

        public Mass_ContryRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateCountry(Mass_contry Country)
        {

               var parameter = new DynamicParameters();
            parameter.Add("@name_", Country.name, dbType: DbType.String, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("country_package_api.insertusercountry", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCountry(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@country_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("country_package_api.deleteusercountry", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_contry> GetallCountry()
        {
            IEnumerable<Mass_contry> result = dbContext.Connection.Query<Mass_contry>("country_package_api.getallusercountry", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateCountry(Mass_contry Country)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@country_id", Country.countryid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@name_", Country.name, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("country_package_api.updateusercountry", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<string> UserAndCountry(int id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@id_contry", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<CountryUserDTO> result = dbContext.Connection.Query<CountryUserDTO>("UserAndCountry", parameter, commandType: CommandType.StoredProcedure);
            List<CountryUserDTO> R = result.ToList();
            List<string> finalResult = new List<string>();



            finalResult.Add("Country Name: " + R[1].Name + " **** User Number :" + R.Count);


            return finalResult;
        }













    }
}
