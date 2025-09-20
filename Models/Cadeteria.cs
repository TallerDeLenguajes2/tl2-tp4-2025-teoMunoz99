namespace Clases
{
    public class Cadeteria
    {
        private const float JORNAL = 500;
        private static int _contador = 0;

        public int Id { get; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public List<Cadete> ListadoCadetes { get; set; }
        public List<Pedido> ListadoPedidos { get; set; }

        public Cadeteria(string _nom, int _tel, List<Cadete> _listCad = null)
        {
            Id = ++_contador;
            this.Nombre = _nom;
            this.Telefono = _tel;
            this.ListadoCadetes = _listCad ?? new List<Cadete>();
            this.ListadoPedidos = new List<Pedido>();
        }

        public IEnumerable<Pedido> ObtenerPedidos(){ return this.ListadoPedidos; }
        public IEnumerable<Cadete> ObtenerCadetes(){ return this.ListadoCadetes; }
        public bool AltaPedido(Pedido _pedido)
        {
            if (_pedido == null)
            {
                return false;
            }
            else
            {
                int cont = ListadoPedidos.Count();
                ListadoPedidos.Add(_pedido);
                if (ListadoPedidos.Count() > cont)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool AsignarPedido(Pedido _pedido, Cadete _cadete)
        {
            if (_pedido != null && _cadete != null)
            {
                _pedido.CadeteAsignado = _cadete;
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
