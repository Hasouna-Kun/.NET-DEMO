using Backend.Context;
using Backend.DTOS;
using Backend.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        private readonly UtilitesContext _db;
        public CategoriesService(UtilitesContext db)
        {
            _db = db;
        }
        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            bool isArabic = true;

            var categories = await _db.Categories.ToListAsync();

            var dto = categories.Select(s => new CategoryDTO { Id = s.Id, Name = isArabic ? s.NameAr : s.NameEn }).ToList();

            return dto;
        }
    }
}
