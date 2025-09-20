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


    //Creo esta clase auxiliar para no exponer toda mi clase pedido en el front
    //consultar en clase !! donde ubicarla, si es buena practica o no.
    public class CrearPedidoDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Referencia { get; set; }
        public string Obs { get; set; }
    }
    //------------------------------

    [HttpPost("pedidos")]
    public IActionResult AgregarPedido([FromBody] CrearPedidoDto dto)
    {
        if (dto == null || string.IsNullOrWhiteSpace(dto.Nombre)) return BadRequest();

        bool ok = _service.AltaPedido(dto.Nombre, dto.Direccion, dto.Telefono, dto.Referencia, dto.Obs);

        return ok ? Created("", null) : BadRequest();
    }

    [HttpPut("pedidos/{idPedido}/asignar/{idCadete}")]
    public IActionResult AsignarPedido(int idPedido, int idCadete)
    {
        var ok = _service.AsignarPedido(idPedido, idCadete);

        return ok ? NoContent() : NotFound();
    }

    [HttpPut("pedidos/{idPedido}/estado/{nuevoEstado}")]
    public IActionResult CambiarEstadoPedido(int idPedido, int nuevoEstado)
    {
        var ok = _service.CambiarEstadoPedido(idPedido, nuevoEstado);

        return ok ? NoContent() : BadRequest();
    }

    [HttpPut("pedidos/{idPedido}/cambiarCadete/{idNuevoCadete}")]
    public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        var ok = _service.AsignarPedido(idPedido, idNuevoCadete);

        return ok ? NoContent() : NotFound();
    }


}