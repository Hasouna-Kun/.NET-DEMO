using Backend.DTOS;
using Backend.Interfaces.Services;
using Backend.Models;
using Backend.Requests;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            var result = await _categoriesService.GetCategoriesById(id ?? 1);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AddCategory category)
        {
            var result = await _categoriesService.AddCategoiresAsync(category);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoriesService.DeleteCategoryAsync(id);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, UpdateCategory categoryChange) 
        {
            var result = await _categoriesService.UpdateCaetogrtAsync(id, categoryChange);
            
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
