using Backend.DTOS;
using Backend.Models;
using Backend.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Interfaces.Services
{
    public interface ICategoriesService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<Category> GetCategoriesById(int id);
        Task<AddCategory> AddCategoiresAsync(AddCategory category);
        Task<UpdateCategory> UpdateCaetogrtAsync(int id , UpdateCategory categoryChange);
        Task DeleteCategoryAsync(int id);
    }
}
