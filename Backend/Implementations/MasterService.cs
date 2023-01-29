using Backend.Context;
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
    public class MasterService : IMasterTransaction
    {
        private readonly UtilitesContext _db;

        public MasterService(UtilitesContext db)
        {
            _db = db;
        }

        public async Task<AddMasterTransaction> AddMasterTransactionAsync(AddMasterTransaction addMaster)
        {
            Transaction transaction = new Transaction();
            transaction.CustomerId = addMaster.CustomerId;
            transaction.Date = addMaster.Date;
            transaction.Discribe = addMaster.Discribe; 
            
            await _db.Transactions.AddAsync(transaction);
            await _db.SaveChangesAsync();

            foreach (var item in addMaster.addDetalis)
            {
                var isExist = await _db.TransactionDetalis.AnyAsync(d => d.CategoryId == item.CategoryId);
                if (isExist)
                {
                    throw new Exception("Category Alredy in Use");
                }

            }

            foreach (var item in addMaster.addDetalis)
            {              
                var addDetali = new TransactionDetali();
                addDetali.CategoryId = item.CategoryId;
                addDetali.TransactionId = item.TransactionId;
                addDetali.Price = item.Price;
                addDetali.RetrievalDate = item.RetrievalDate;
                await _db.TransactionDetalis.AddAsync(addDetali);
            }
            await _db.SaveChangesAsync();
            return addMaster;
        }

        public async Task DeleteMasterAsync(int id)
        {
            var Master = await _db.Transactions.FindAsync(id);
            if(Master == null)
            {
                throw new Exception("");
            }
            _db.Transactions.Remove(Master);

            var Detali = await _db.TransactionDetalis.Where(x => x.TransactionId == id).ToListAsync();
            foreach (var item in Detali)
            {
                _db.TransactionDetalis.Remove(item);
            }
            await _db.SaveChangesAsync();
        }

        public async Task<UpdateMasterTransaction> UpdateMasterTransactionAsync(int id, UpdateMasterTransaction updateMaster)
        {
            var Master = await _db.Transactions.FindAsync(id);
            Master.CustomerId = updateMaster.CustomerId;
            Master.Date = updateMaster.Date;
            Master.Discribe = updateMaster.Discribe;

            _db.Entry(Master).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _db.SaveChangesAsync();

            var Detalis = await _db.TransactionDetalis.Where(x => x.TransactionId == id).ToListAsync();
            foreach (var item in Detalis)
            {
                _db.TransactionDetalis.Remove(item);
            }

            foreach (var item in updateMaster.UpdateDetalis)
            {
                var detali = new TransactionDetali();
                detali.CategoryId = item.CategoryId;
                detali.RetrievalDate = item.RetrievalDate;
                detali.Price = item.Price;
                detali.TransactionId = item.TransactionId;
                await _db.TransactionDetalis.AddAsync(detali);
            }
            await _db.SaveChangesAsync();
            return updateMaster;
        }
    }
}
