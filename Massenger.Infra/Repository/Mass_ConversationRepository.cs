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
    public class Mass_ConversationRepository : IMass_ConversationRepository
    {
        private readonly IDbContext dbContext;

        public Mass_ConversationRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public bool CreateConversation(Mass_conversation Conversation)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@title_", Conversation.title, dbType: DbType.String, direction: ParameterDirection.Input);
           
            var result = dbContext.Connection.ExecuteAsync("conversation_package_api.insertconversation", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteConversation(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@conversation_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("conversation_package_api.deleteconversation", parameter, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<Mass_conversation> GetallConversation()
        {
            IEnumerable<Mass_conversation> result = dbContext.Connection.Query<Mass_conversation>("conversation_package_api.getallconversation", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool UpdateConversation(Mass_conversation Conversation)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@title_", Conversation.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("@conversation_id", Conversation.title, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("conversation_package_api.updateconversation", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }
    }
}
