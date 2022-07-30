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
    public class BlockController : ControllerBase
    {
        private readonly IMass_BlockService bookService;
        public BlockController(IMass_BlockService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
      public List<Mass_block> Getallblock()
        {

            return bookService.Getallblock();
        }
        [HttpPost]
        
        public bool createinsertblock([FromBody] Mass_block block)
        {
            return bookService.Createblock(block);
        }
        [HttpPut]
       
        public bool Updateblock(Mass_block block)
        {
            return bookService.Updateblock(block);
        }

        [HttpDelete("delete/{id}")]

        public bool deleteblock(int? id)
        {
            return bookService.Deleteblock(id);
        }








    }
}
