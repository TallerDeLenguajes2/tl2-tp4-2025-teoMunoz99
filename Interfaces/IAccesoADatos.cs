namespace Interfaces
{
    using Clases;
    using System.Collections.Generic;

    public interface IAccesoADatos
    {
        List<Cadete> CargarCadetes(string _ruta);
        Cadeteria CargarCadeteria(string _ruta, List<Cadete> cadetes);
    }
}