using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Delivery.Web.Data;
using Delivery.Web.Data.Entities;
using Delivery.Web.Helpers;

namespace Delivery.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepartidoresController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public RepartidoresController(DataContext context,
                                      IConverterHelper converterHelper)
        {
            _context = context;
            _converterHelper = converterHelper;
        }



        // GET: api/Repartidores/5
        [HttpGet("{placa}")]
        public async Task<IActionResult> GetRepartidorEntity([FromRoute] string placa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RepartidorEntity repartidorEntity = await _context.Repartidores
                .Include(r => r.Usuario) // codcutore
                .Include(r=> r.Viajes)
                .ThenInclude(r=> r.DetalleViajes)
                .Include(r=>r.Viajes)
                .ThenInclude(r=>r.Usuario)  // usuario pedido 
                .FirstOrDefaultAsync(r => r.Placa == placa);

            if (repartidorEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHelper.ToRepartidorResponse(repartidorEntity));
        }

        
    }
}