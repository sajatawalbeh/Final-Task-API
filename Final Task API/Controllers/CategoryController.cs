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
    public class CategoryController : ControllerBase
    {
        private readonly IMass_CategoryService CategoryService;
        public CategoryController(IMass_CategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }

        [HttpGet]
        public List<Mass_category> Getalluser()
        {

            return CategoryService.GetallCategory();
        }
        [HttpPost]

        public bool createinsertuser([FromBody] Mass_category category)
        {
            return CategoryService.CreateCategory(category);
        }
        [HttpPut]

        public bool Updateuser(Mass_category category)
        {
            return CategoryService.UpdateCategory(category);
        }

        [HttpDelete("delete/{id}")]

        public bool deleteuser(int? id)
        {
            return CategoryService.DeleteCategory(id);
        }

    }
}
