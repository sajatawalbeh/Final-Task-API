using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using Massenger.Core.Common;
using Massenger.Core.Data;
using Massenger.Core.Repository;

namespace Massenger.Infra.Repository
{
  public  class JwtRepository: IJwtRepository
    {
        private readonly IDbContext dbContext;

        public JwtRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Mass_Login Auth(Mass_Login login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("Uname", login.username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("pass", login.password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<Mass_Login> result = dbContext.Connection.Query<Mass_Login>("User_Login2", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

       
      
    }
}
