using AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class CuentasController : ControllerBase
{
    private readonly BancoContext _context;

    public CuentasController(BancoContext context)
    {
        _context = context;
    }

    // GET: api/Cuentas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cuenta>>> GetCuentas()
    {
        return await _context.Cuentas.ToListAsync();
    }

    // GET: api/Cuentas/5
    [HttpGet("{idTarjeta}")]
    public async Task<ActionResult<Cuenta>> GetCuentaDeTarjeta(int idTarjeta)
    {
        var tarjeta = _context.Cuentas.Where(c => c.idTarjeta == idTarjeta).FirstOrDefault();

        if (tarjeta == null)
        {
            return NotFound();
        }

        return tarjeta;
    }

    // POST: api/Cuentas
    [HttpPost]
    public async Task<ActionResult<Cuenta>> PostTarjeta(Cuenta cuenta)
    {
        _context.Cuentas.Add(cuenta);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetTarjeta", new { id = cuenta.idCuenta }, cuenta);
    }

    // PUT: api/Cuentas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarjeta(int id, Cuenta tarjeta)
    {
        if (id != tarjeta.idCuenta)
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
            if (!_context.Cuentas.Any(e => e.idCuenta == id))
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

    // DELETE: api/Cuentas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCuenta(int idTarjeta)
    {
        var cuenta = await _context.Cuentas.FindAsync(idTarjeta);
        if (cuenta == null)
        {
            return NotFound();
        }

        _context.Cuentas.Remove(cuenta);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}