using Backend.Context;
using Backend.DTOS;
using Backend.Interfaces.Services;
using Backend.Models;
using Backend.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly UtilitesContext _db;

        public CustomerService(UtilitesContext db)
        {
            _db = db;
        }

        public async Task<AddCustomer> AddCustomerAsync(AddCustomer customer)
        {
            Customer Customer = new Customer();
            Customer.NameAr = customer.NameAr;
            Customer.NameEn = customer.NameEn;
            Customer.Phone = customer.Phone;
            Customer.City = customer.City;

            await _db.Customers.AddAsync(Customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if(customer == null)
            {
                throw new Exception("Cannot Found Customer");
            }
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            bool isArabic = false;

            var customers = await _db.Customers.ToListAsync();
            var dto = customers.Select(c => new CustomerDTO { id = c.Id, Name = isArabic ? c.NameAr : c.NameEn, City = c.City }).ToList();
            return dto;
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            bool isArabic = true;
            CustomerDTO dto = new CustomerDTO();
            var customers = await _db.Customers.FindAsync(id);

            dto.id = customers.Id;
            if(isArabic == true)
            {
                dto.Name = customers.NameAr;
            }
            else
            {
                dto.Name = customers.NameEn;
            }

            dto.City = customers.City;

            return dto;
        }

        public async Task<UpdateCustomer> UpdateCustomerAsync(int id, UpdateCustomer customerChange)
        {
            var customer = await _db.Customers.FindAsync(id);
            if(customer == null)
            {
                throw new Exception("This Customer Cannot Be Found");
            }

            customer.NameAr = customerChange.NameAr;
            customer.NameEn = customerChange.NameEn;
            customer.Phone = customerChange.Phone;
            customer.City = customerChange.City;
            _db.Entry(customer).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return customerChange;
        }
    }
}
