using System;
using System.Collections.Generic;
using Clases;

namespace Interfaces
{
    public class InformeCadete
    {
        public string Nombre { get; set; }
        public int CantidadEntregados { get; set; }
        public float Jornal { get; set; }
    }

    public class InformeGeneral
    {
        public List<InformeCadete> DetalleCadetes { get; set; } = new List<InformeCadete>();
        public float TotalGeneral { get; set; }
    }
    public interface ICadeteriaService
    {
        bool AltaPedido(string _nombre, string _direccion, int _telefono, string _referencia, string _obs);
        bool AsignarPedido(int _idPedido, int _idCadete);
        bool CambiarEstadoPedido(int _idPedido, int _opcion);
        InformeGeneral MostrarInforme();
        IEnumerable<Pedido> ObtenerPedidos();
        IEnumerable<Cadete> ObtenerCadetes();

    }
}