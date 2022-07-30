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
    public class Mass_ParticipantsRepository : IMass_ParticipantsRepository
    {
        private readonly IDbContext dbContext;

        public Mass_ParticipantsRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateParticipants(Mass_participants Participants)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@phone_", Participants.conversation_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Email_", Participants.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@type_", Participants.type, dbType: DbType.String, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("participants_package_api.insertparticipants", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteParticipants(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@participants_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("participants_package_api.deleteparticipants", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_participants> GetallParticipants()
        {
            IEnumerable<Mass_participants> result = dbContext.Connection.Query<Mass_participants>("participants_package_api.getallparticipants", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateParticipants(Mass_participants Participants)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@participants_id", Participants.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@phone_", Participants.conversation_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@Email_", Participants.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@type_", Participants.type, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("participants_package_api.updateparticipants", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
