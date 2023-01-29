using Backend.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Interfaces.Services
{
    public interface IMasterTransaction
    {
        Task<AddMasterTransaction> AddMasterTransactionAsync(AddMasterTransaction addMaster);
        Task<UpdateMasterTransaction> UpdateMasterTransactionAsync(int id, UpdateMasterTransaction updateMaster);
        Task DeleteMasterAsync(int id);
    }
}
