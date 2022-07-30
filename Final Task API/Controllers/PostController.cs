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
    public class PostController : ControllerBase
    {
        private readonly IMass_PostService postservice;
        public PostController(IMass_PostService postservice)
        {
            this.postservice = postservice;
        }

        [HttpGet]
        public List<Mass_Post> Getallpost()
        {

            return postservice.Getallpost();
        }
        [HttpPost]

        public bool createinsertpost([FromBody] Mass_Post post)
        {
            return postservice.Createpost(post);
        }
        [HttpPut]

        public bool Updatepost(Mass_Post post)
        {
            return postservice.Updatepost(post);
        }

        [HttpDelete("delete/{id}")]

        public bool deletepost(int? id)
        {
            return postservice.Deletepost(id);
        }
        [HttpGet("likesnum/{id}")]
        public List<string> GetlikesEachPost(int id)
        {
            return postservice.GetlikesEachPost(id);
        }

    }
}
