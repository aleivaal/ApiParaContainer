using AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TarjetasController : ControllerBase
{
    private readonly BancoContext _context;

    public TarjetasController(BancoContext context)
    {
        _context = context;
    }

    // GET: api/Tarjetas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarjeta>>> GetTarjetas()
    {
        return await _context.Tarjetas.ToListAsync();
    }

    // GET: api/Tarjetas/5
    [HttpGet("{idCliente}")]
    public async Task<ActionResult<IEnumerable<Tarjeta>>> GetTarjetas(int idCliente)
    {
        var tarjeta = await _context.Tarjetas.Where(c => c.IdCliente == idCliente).ToListAsync();

        if (tarjeta == null)
        {
            return NotFound();
        }

        return tarjeta;
    }

    // POST: api/Tarjetas
    [HttpPost]
    public async Task<ActionResult<Tarjeta>> PostTarjeta(Tarjeta tarjeta)
    {
        _context.Tarjetas.Add(tarjeta);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTarjeta", new { id = tarjeta.idTarjeta }, tarjeta);
    }

    // PUT: api/Tarjetas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarjeta(int id, Tarjeta tarjeta)
    {
        if (id != tarjeta.idTarjeta)
        {
            return BadRequest();
        }

        _context.Entry(tarjeta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tarjetas.Any(e => e.idTarjeta == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Tarjetas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Tarjetas.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Tarjetas.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}