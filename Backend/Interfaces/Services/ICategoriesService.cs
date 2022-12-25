using Backend.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Interfaces.Services
{
    public interface ICategoriesService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
    }
}
