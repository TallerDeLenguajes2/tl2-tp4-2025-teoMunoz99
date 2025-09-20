using System;
using System.Collections.Generic;
using System.Linq;
using Clases;
using Interfaces;

namespace Services
{
    public class CadeteriaService : ICadeteriaService
    {
        private Cadeteria _cadeteria;

        public CadeteriaService(Cadeteria cadeteria)
        {
            _cadeteria = cadeteria;
        }

        public bool AltaPedido(string _nombre, string _direccion, int _telefono, string _referencia, string _obs)
        {

            Cliente cliente = new Cliente(_nombre, _direccion, _telefono, _referencia);
            Pedido pedido = new Pedido(cliente, _obs);
            return _cadeteria.AltaPedido(pedido);

        }

        public bool AsignarPedido(int _idPedido, int _idCadete)
        {
            var pedido = _cadeteria.ObtenerPedidos().FirstOrDefault(p => p.Id == _idPedido);
            if (pedido == null) return false;

            var cadete = _cadeteria.ObtenerCadetes().FirstOrDefault(c => c.Id == _idCadete);
            if (cadete == null) return false;

            return _cadeteria.AsignarPedido(pedido, cadete);
        }

        public bool CambiarEstadoPedido(int _idPedido, int _opcion)
        {
            var pedido = ObtenerPedidos().FirstOrDefault(p => p.Id == _idPedido);
            if (pedido == null) return false;

            if (!Enum.IsDefined(typeof(EstadoPedido), _opcion)) return false;
            EstadoPedido estado = (EstadoPedido)_opcion;

            return pedido.CambiarEstadoPedido(estado);
        }
        public Interfaces.InformeGeneral MostrarInforme()
        {
            var informe = new Interfaces.InformeGeneral();
            var cadetes = _cadeteria.ObtenerCadetes().ToList();
            var pedidos = _cadeteria.ObtenerPedidos().ToList();

            foreach (var cadete in cadetes)
            {
                int entregados = pedidos.Count(p => p.CadeteAsignado == cadete && p.EstadoPedido == EstadoPedido.ENTREGADO);
                float jornal = entregados * 500; // o usar una constante JORNAL desde Cadeteria si la expones
                informe.DetalleCadetes.Add(new Interfaces.InformeCadete
                {
                    Nombre = cadete.Nombre,
                    CantidadEntregados = entregados,
                    Jornal = jornal
                });
                informe.TotalGeneral += jornal;
            }

            return informe;
        }

        public IEnumerable<Pedido> ObtenerPedidos()
        {
            return _cadeteria.ObtenerPedidos();
        }
        public IEnumerable<Cadete> ObtenerCadetes()
        {
            return _cadeteria.ObtenerCadetes();
        }
    }
}