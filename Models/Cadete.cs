using System.Timers;

namespace Clases
{
    public class Cadete
    {
        //private const float JORNAL = 500;
        private static int _contador = 0;
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }

        public Cadete() { }
        public Cadete(string _nom, string _dir, int _tel)
        {
            Id = ++_contador;
            this.Nombre = _nom;
            this.Direccion = _dir;
            this.Telefono = _tel;
        }

    }



}