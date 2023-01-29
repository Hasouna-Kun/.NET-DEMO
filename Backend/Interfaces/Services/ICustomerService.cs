using Backend.DTOS;
using Backend.Models;
using Backend.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO> GetCustomerByIdAsync(int id);
        Task<AddCustomer> AddCustomerAsync(AddCustomer customer);
        Task DeleteCustomerAsync(int id);
        Task<UpdateCustomer> UpdateCustomerAsync(int id, UpdateCustomer customerChange);
    }
}
