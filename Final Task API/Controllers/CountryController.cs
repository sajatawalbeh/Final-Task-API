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
    public class CountryController : ControllerBase
    {
        private readonly IMass_ContryService countryService;
        public CountryController(IMass_ContryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public List<Mass_contry> Getallcountry()
        {

            return countryService.GetallCountry();
        }
        [HttpPost]

        public bool createinsertcountry([FromBody] Mass_contry contry)
        {
            return countryService.CreateCountry(contry);
        }
        [HttpPut]

        public bool Updatecountry(Mass_contry contry)
        {
            return countryService.UpdateCountry(contry);
        }

        [HttpDelete("delete/{id}")]

        public bool deletecountry(int? id)
        {
            return countryService.DeleteCountry(id);
        }

        [HttpGet("UserAndCountry/{id}")]
        public List<string> UserAndCountry(int id)
        {
            return countryService.UserAndCountry(id);
        }

    }
}
