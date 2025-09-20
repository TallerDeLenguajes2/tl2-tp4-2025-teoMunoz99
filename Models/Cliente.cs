namespace Clases
{
    public class Cliente
    {
        private static int _contador = 0;
        public int Id { get;}
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string DatosReferenciaDireccion { get; set; }
        public Cliente(string _nom, string _dir, int _tel, string _datRefDir = null)
        {
            Id = ++_contador;
            this.Nombre = _nom;
            this.Direccion = _dir;
            this.Telefono = _tel;
            this.DatosReferenciaDireccion = _datRefDir;
        }
    }
}


