using Dapper;
using MailKit.Net.Smtp;
using Massenger.Core.Common;
using Massenger.Core.Data;
using Massenger.Core.Repository;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Massenger.Infra.Repository
{
    public class Mass_BlockRepository : IMass_BlockRepository
    {
        private readonly IDbContext dbContext;

        public Mass_BlockRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool Createblock(Mass_block block)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@userid", block.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@participantsid", block.participants_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@createdAt", block.created_at, dbType: DbType.DateTime, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("block_package_api.insertblock", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool Deleteblock(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@block_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("block_package_api.deleteblock", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_block> Getallblock()
        {

            IEnumerable<Mass_block> result = dbContext.Connection.Query<Mass_block>("users_package_api.getalluser", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool Updateblock(Mass_block block)
        {

            var parameter = new DynamicParameters();
            parameter.Add("@block_id", block.blockid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@userid", block.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@participantsid", block.participants_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@createdAt", block.created_at, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("block_package_api.updateblock", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

      

    }
}
