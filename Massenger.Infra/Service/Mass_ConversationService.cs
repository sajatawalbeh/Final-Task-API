using Massenger.Core.Data;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
    public class Mass_ConversationService : IMass_ConversationService
    {
        private readonly IMass_ConversationRepository repo;
        public Mass_ConversationService(IMass_ConversationRepository repo)
        {
            this.repo = repo;
        }
        public bool CreateConversation(Mass_conversation Conversation)
        {
            return repo.CreateConversation(Conversation);   
        }

        public bool DeleteConversation(int? id)
        {
            return repo.DeleteConversation(id);
        }

        public List<Mass_conversation> GetallConversation()
        {
            return repo.GetallConversation();
        }

        public bool UpdateConversation(Mass_conversation Conversation)
        {
            return repo.UpdateConversation(Conversation);
        }
    }
}
