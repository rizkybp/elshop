using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CoreApplication.Services;
using CoreApplication.Entities;
using Infrastucture.Services;
namespace ElShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransaksiNasabahController : ControllerBase
    {
        private ITransaksiNasabah _transaksiNasabahService;
        public TransaksiNasabahController(ITransaksiNasabah transaksiNasabahService)
        {
            _transaksiNasabahService = transaksiNasabahService;
        }

        [HttpGet]
        [Route("TransaksiNasabah/{id}")]
        public async Task<IActionResult> getByid(string id, CancellationToken cancellationToken)
        {
           
            var currentEditors = await _transaksiNasabahService.GetByIdAsync(id, cancellationToken);
            return Ok(currentEditors);
        }

        [HttpGet]
        [Route("TransaksiNasabah")]
        public async Task<IActionResult> getAll(CancellationToken cancellationToken)
        {

            var ListItem = await _transaksiNasabahService.ListAllAsync(cancellationToken);
            return Ok(ListItem);
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken cancellationToken)
        {

            var itemToDelete = await _transaksiNasabahService.GetByIdAsync(id, cancellationToken);
            if (itemToDelete == null)
                throw new Exception( typeof(TransaksiNasabah).ToString() + id +  "Not Found" );

            // delete data
            var result = await _transaksiNasabahService.DeleteAsync(itemToDelete, cancellationToken);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] TransaksiNasabah transaksiNasabah, CancellationToken cancellationToken)
        {
           
           

            var newItem = await _transaksiNasabahService.AddAsync(transaksiNasabah, cancellationToken);
            if (newItem == null)
            {
             
                return ValidationProblem();
            }
            var obj = await _transaksiNasabahService.GetByIdAsync(newItem.Id.ToString(), cancellationToken);
            return Ok(obj);
           // return Ok(newItem); 
           // return Ok(newItem); 
            //return CreatedAtAction(nameof(getByid), new { id = newItem.Id }, null);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateAsync([FromBody] TransaksiNasabah transaksiNasabah, CancellationToken cancellationToken)
        {
           

            var result = await _transaksiNasabahService.UpdateAsync(transaksiNasabah, cancellationToken);
            if (!result)
            {
               
                return ValidationProblem();
            }
            var obj = await _transaksiNasabahService.GetByIdAsync(transaksiNasabah.Id.ToString(), cancellationToken);
            return Ok(obj);
            //return CreatedAtAction(nameof(getByid), new { id = transaksiNasabah.Id }, null);
        }
    }
}
