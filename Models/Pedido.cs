

namespace Clases
{
    public enum EstadoPedido
    {
        PENDIENTE,
        ENTREGADO,
        CANCELADO
    }
    public class Pedido
    {
        private static int _contador = 0;
        public int Id { get; }
        public string Obs { get; set; }
        public Cliente Cliente { get; set; }
        public EstadoPedido EstadoPedido { get; set; }
        public Cadete CadeteAsignado { get; set; }

        public Pedido() { }
        public Pedido(Cliente _cliente, string _obs = "-")
        {
            Id = ++_contador;
            this.Obs = _obs;
            this.Cliente = _cliente;
            this.EstadoPedido = EstadoPedido.PENDIENTE;
            this.CadeteAsignado = null;
        }

        public string VerDireccionCliente()
        {
            return Cliente.Direccion;
        }

        public string VerDatosCliente()
        {
            return $"Nombre: {Cliente.Nombre},Direccion: {Cliente.Direccion},Teléfono: {Cliente.Telefono},Datos ref: {Cliente.DatosReferenciaDireccion}";
        }

        public bool CambiarEstadoPedido(EstadoPedido _estado)
        {
            this.EstadoPedido = _estado;
            return true;
        }

    }
}