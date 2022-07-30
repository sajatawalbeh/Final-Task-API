using Massenger.Core.Data;
using Massenger.Core.DTO;
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
    public class ServiceController : ControllerBase
    {
        private readonly IMass_ServiceService Service;
        public ServiceController(IMass_ServiceService Service)
        {
            this.Service = Service;
        }

        [HttpGet]
        public List<Mass_Service> Getallervice()
        {

            return Service.GetallService();
        }
        [HttpPost]

        public bool createinsertervice([FromBody] Mass_Service services)
        {
            return Service.CreateService(services);
        }
        [HttpPut]

        public bool Updateervice(Mass_Service services)
        {
            return Service.UpdateService(services);
        }

        [HttpDelete("delete/{id}")]

        public bool deleteervice(int? id)
        {
            return Service.DeleteService(id);
        }
        [HttpPost("Payment")]
        public string Payment([FromBody]VisaDTO visa)
        {
            return Service.Payment(visa);
        }
    }
}
