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
    public class Mass_ContactUserRepository : IMass_User_contactRepository
    {
        private readonly IDbContext dbContext;

        public Mass_ContactUserRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool Createusercontact(Mass_user_contact usercontact)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@firstName", usercontact.firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@lastName", usercontact.lastName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@userID", usercontact.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@contactsid", usercontact.contacts_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("userContact_package_api.insertuserContact", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Deleteusercontact(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@userContact_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("userContact_package_api.deleteuserContact", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_user_contact> Getallusercontact()
        {
            IEnumerable<Mass_user_contact> result = dbContext.Connection.Query<Mass_user_contact>("userContact_package_api.getalluserContact", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool Updateusercontact(Mass_user_contact usercontact)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@userContact_id", usercontact.user_contactid, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@firstName", usercontact.firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@lastName", usercontact.lastName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("@userID", usercontact.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@contactsid", usercontact.contacts_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("userContact_package_api.updateuserContact", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
