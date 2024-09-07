using HumanOperationsAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiHumanos.Models;
using WebApiHumanos.DTOs;

namespace WebApiHumanos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HumanoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Humano
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Humano>>> GetHumanos()
        {
            try
            {
                var humanos = await _context.Humanos.ToListAsync();
                return Ok(humanos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener los humanos", details = ex.Message });
            }
        }

        // GET: api/Humano/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Humano>> GetHumano(int id)
        {
            try
            {
                var humano = await _context.Humanos.FindAsync(id);
                if (humano == null)
                {
                    return NotFound(new { message = $"Humano con ID {id} no encontrado." });
                }

                return Ok(humano);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener el humano", details = ex.Message });
            }
        }

        // POST: api/Humano
        [HttpPost]
        public async Task<ActionResult<Humano>> PostHumano(Humano humano)
        {
            try
            {
                if (humano == null)
                {
                    return BadRequest(new { message = "Datos de humano no válidos." });
                }

                _context.Humanos.Add(humano);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetHumano), new { id = humano.Id }, humano);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, new { message = "Error al crear el humano en la base de datos.", details = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error inesperado al crear el humano.", details = ex.Message });
            }
        }

        // PUT: api/Humano/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHumano(int id, HumanoUpdateDto humanoDto)
        {
            try
            {
                var humano = await _context.Humanos.FindAsync(id);
                if (humano == null)
                {
                    return NotFound(new { message = $"Humano con ID {id} no encontrado." });
                }

                if (!string.IsNullOrEmpty(humanoDto.Nombre))
                {
                    humano.Nombre = humanoDto.Nombre;
                }

                if (!string.IsNullOrEmpty(humanoDto.Sexo))
                {
                    humano.Sexo = humanoDto.Sexo;
                }

                if (humanoDto.Edad.HasValue)
                {
                    humano.Edad = humanoDto.Edad.Value;
                }

                if (humanoDto.Altura.HasValue)
                {
                    humano.Altura = humanoDto.Altura.Value;
                }

                if (humanoDto.Peso.HasValue)
                {
                    humano.Peso = humanoDto.Peso.Value;
                }

                _context.Entry(humano).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HumanoExists(id))
                {
                    return NotFound(new { message = $"Humano con ID {id} no encontrado para actualizar." });
                }
                else
                {
                    return StatusCode(500, new { message = "Error de concurrencia al actualizar el humano." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error inesperado al actualizar el humano.", details = ex.Message });
            }
        }


        private bool HumanoExists(int id)
        {
            try
            {
                return _context.Humanos.Any(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar si el humano existe.", ex);
            }
        }
    }
}
