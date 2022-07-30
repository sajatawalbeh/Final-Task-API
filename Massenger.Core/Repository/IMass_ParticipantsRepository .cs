using Massenger.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Core.Repository
{
    public interface IMass_ParticipantsRepository
    {
        public List<Mass_participants> GetallParticipants();

        public bool CreateParticipants(Mass_participants Participants);

        public bool DeleteParticipants(int? id);

        public bool UpdateParticipants(Mass_participants Participants);
    }
}
