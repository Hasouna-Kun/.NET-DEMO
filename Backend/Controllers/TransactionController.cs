using Backend.Interfaces.Services;
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
    public class TransactionController : ControllerBase
    {
        private readonly IMasterTransaction _masterTransaction;

        public TransactionController(IMasterTransaction masterTransaction)
        {
            _masterTransaction = masterTransaction;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AddMasterTransaction addMaster)
        {
            var Tran = await _masterTransaction.AddMasterTransactionAsync(addMaster);
           
            return Ok(Tran);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(int id ,UpdateMasterTransaction updateMaster)
        {
            var reslut = await _masterTransaction.UpdateMasterTransactionAsync(id, updateMaster);
            return Ok(reslut);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _masterTransaction.DeleteMasterAsync(id);
            return Ok();
        }

    }
}
