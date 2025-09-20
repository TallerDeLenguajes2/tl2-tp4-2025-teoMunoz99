using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Clases;
using Interfaces;
using Helpers;
using Services;

[ApiController]
[Route("api/[controller]")]
public class CadeteriaController : ControllerBase
{
    private CadeteriaService _service;

    public CadeteriaController()
    {
        _service = AppData.CadeteriaService;
    }

    [HttpGet("pedidos")]
    public ActionResult<IEnumerable<Pedido>> GetPedidos()
    {
        var pedidos = _service.ObtenerPedidos();

        if (!pedidos.Any()) return Ok(new List<Pedido>());

        return Ok(pedidos);
    }

    [HttpGet("cadetes")]
    public ActionResult<IEnumerable<Cadete>> GetCadetes()
    {
        var cadetes = _service.ObtenerCadetes();

        if (!cadetes.Any()) return Ok(new List<Cadete>());

        return Ok(cadetes);
    }

    [HttpGet("informe")]
    public ActionResult<object> GetInforme()
    {
        var info = _service.MostrarInforme();

        if (info == null || !info.DetalleCadetes.Any()) return NoContent();

        return Ok(info);
    }
}