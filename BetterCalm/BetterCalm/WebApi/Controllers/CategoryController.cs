using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterCalm.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public object Get()
        {
            List<Category> categories = new List<Category>();
            Category category = new Category();
            categories.Add(category);
            return Ok(categories);
        }
    }
}
