using Backend.DTOS;
using Backend.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilitesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        public UtilitesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var result = await _categoriesService.GetAllCategoriesAsync();

            return Ok(result);
        }
    }
}
