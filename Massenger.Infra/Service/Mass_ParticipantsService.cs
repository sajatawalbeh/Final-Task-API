using Massenger.Core.Data;
using Massenger.Core.Repository;
using Massenger.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Massenger.Infra.Service
{
    public class Mass_ParticipantsService : IMass_ParticipantsService
    {
        private readonly IMass_ParticipantsRepository repo;
        public Mass_ParticipantsService(IMass_ParticipantsRepository repo)
        {
            this.repo = repo;
        }
        public bool CreateParticipants(Mass_participants Participants)
        {
            return repo.CreateParticipants(Participants);
        }

        public bool DeleteParticipants(int? id)
        {
            return repo.DeleteParticipants(id);
        }

        public List<Mass_participants> GetallParticipants()
        {
            return repo.GetallParticipants();
        }

        public bool UpdateParticipants(Mass_participants Participants)
        {
            return repo.UpdateParticipants(Participants);
        }
    }
}
