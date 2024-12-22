using AccesoDatos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos;
using MSClientes.ServiciosExternos;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly BancoContext _context;
    private readonly IServicioTarjetas _elServicioTarjetas;

    public ClientesController(BancoContext context, IServicioTarjetas elServicioTarjetas )
    {

        _context = context;
        this._elServicioTarjetas = elServicioTarjetas;
    }

    // GET: api/Clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpGet("GetClientesConTarjetas")]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientesConTarjetas()
    {
        
        var losClientes = await _context.Clientes.ToListAsync();
        foreach (var cliente in losClientes)
        {
            cliente.Tarjetas = await _elServicioTarjetas.obtenerTarjetasDeCliente(cliente.IdCliente);
        }
        return losClientes;
    }


    // GET: api/Clientes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return cliente;
    }

    // POST: api/Clientes
    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
    }

    // PUT: api/Clientes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(int id, Cliente cliente)
    {
        if (id != cliente.IdCliente)
        {
            return BadRequest();
        }

        _context.Entry(cliente).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Clientes.Any(e => e.IdCliente == id))
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

    // DELETE: api/Clientes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}