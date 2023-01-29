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
    public class CategoriesService : ICategoriesService
    {
        private readonly UtilitesContext _db;
        public CategoriesService(UtilitesContext db)
        {
            _db = db;
        }

        public async Task<AddCategory> AddCategoiresAsync(AddCategory category)
        {
            var isExists = await _db.Categories.AnyAsync(x => x.NameAr == category.NameAr || x.NameEn == category.NameEn);

            if (isExists)
                throw new Exception("category already registered");

            var Category = new Category();

            Category.NameAr = category.NameAr;
            Category.NameEn = category.NameEn;


            await _db.Categories.AddAsync(Category);
            await _db.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            Category category = await _db.Categories.FindAsync(id);
            if(category != null)
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            bool isArabic = true;

            var categories = await _db.Categories.ToListAsync();

            var dto = categories.Select(s => new CategoryDTO { Id = s.Id, Name = isArabic ? s.NameAr : s.NameEn }).ToList();

            return dto;
        }

        public async Task<Category> GetCategoriesById(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<UpdateCategory> UpdateCaetogrtAsync(int id,UpdateCategory categoryChange)
        {
            var cataegory = await _db.Categories.FindAsync(id);
            if(cataegory == null)
            {
                throw new Exception("Gategory cannot be Found");
            }
            cataegory.NameAr = categoryChange.NameAr;
            cataegory.NameEn = categoryChange.NameEn;
            _db.Entry(cataegory).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return categoryChange;
        }

        
    }
}
