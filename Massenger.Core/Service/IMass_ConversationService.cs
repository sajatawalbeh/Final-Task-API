using Massenger.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Service
{
   public  interface IMass_ConversationService
    {
        public List<Mass_conversation> GetallConversation();

        public bool CreateConversation(Mass_conversation Conversation);

        public bool DeleteConversation(int? id);

        public bool UpdateConversation(Mass_conversation Conversation);
    }
}
