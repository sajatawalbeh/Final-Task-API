using Dapper;
using Massenger.Core.Common;
using Massenger.Core.Data;
using Massenger.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Massenger.Infra.Repository
{

    public class Mass_ContactRepository : IMass_ContactRepository
    {

        private readonly IDbContext dbContext;

        public Mass_ContactRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Createcontact(Mass_contacts contact)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@firstName", contact.first_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@lastName", contact.last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@phone_", contact.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Email_", contact.email, dbType: DbType.String, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("contact_package_api.createinsertcontact", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Deletecontact(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@contact_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("contact_package_api.deletecontact", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_contacts> Getallcontact()
        {
            IEnumerable<Mass_contacts> result = dbContext.Connection.Query<Mass_contacts>("contact_package_api.getallcontact", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool Updatecontact(Mass_contacts contact)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@contact_id", contact.id, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@firstName", contact.first_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@lastName", contact.last_Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@phone_", contact.phone, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@Email_", contact.email, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("contact_package_api.updatecontact", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
