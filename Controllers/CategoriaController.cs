using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeliculaAPI.Data;
using PeliculaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeliculaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CategoriaController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Categoria))]
        [ProducesResponseType(400)] // Bad Request (Solicitud incorrecta)
        [ProducesResponseType(404)] // not Faund (no encontrada)
        public async Task<IActionResult> GetCategoria()
        {
            var lista = await _db.Categorias.OrderBy(c => c.Nombre).ToListAsync();

            return Ok(lista);
        }


        [HttpGet("{id:int}" , Name = "GetCategoria")]
        [ProducesResponseType(200, Type = typeof(List<Categoria>))]
        [ProducesResponseType(400)] // Bad Request
        public async Task<IActionResult> GetCategoria(int id)
        {
            var obj = await _db.Categorias.FirstOrDefaultAsync(c => c.Id == id);


            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)] // Error interno

        public async Task<IActionResult> CrearCategoria([FromBody] Categoria categoria)
        {
            if(categoria==null)
            {
                return BadRequest(ModelState);

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(categoria);
            await _db.SaveChangesAsync();

            return CreatedAtRoute("GetCategoria", new { id = categoria.Id }, categoria);

        }
    }


}
