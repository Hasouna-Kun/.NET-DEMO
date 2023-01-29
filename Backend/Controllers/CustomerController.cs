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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _customerService.GetAllCustomersAsync();
            
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if(customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AddCustomer customer)
        {
            var reslut = await _customerService.AddCustomerAsync(customer);
            return Ok(reslut);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id, UpdateCustomer customerChange)
        {
            var customer = await _customerService.UpdateCustomerAsync(id, customerChange);
            if(customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}
