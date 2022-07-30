using Massenger.Core.Data;
using Massenger.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Task_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IMass_ParticipantsService Participantsservice;
        public ParticipantsController(IMass_ParticipantsService Participantsservice)
        {
            this.Participantsservice = Participantsservice;
        }

        [HttpGet]
        public List<Mass_participants> GetallParticipants()
        {

            return Participantsservice.GetallParticipants();
        }
        [HttpPost]

        public bool createinsertParticipants([FromBody] Mass_participants participants)
        {
            return Participantsservice.CreateParticipants(participants);
        }
        [HttpPut]

        public bool UpdateParticipants(Mass_participants participants)
        {
            return Participantsservice.UpdateParticipants(participants);
        }

        [HttpDelete("delete/{id}")]

        public bool deleteParticipants(int? id)
        {
            return Participantsservice.DeleteParticipants(id);
        }


    }
}
