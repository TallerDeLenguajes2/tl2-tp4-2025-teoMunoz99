using Services;

namespace Helpers
{
    public static class AppData
    {
        public static CadeteriaService CadeteriaService { get; }

        static AppData()
        {
            var acceso = new AccesoADatosCSV();
            var cadetes = acceso.CargarCadetes("Data/cadetes.csv");
            var cadeteria = acceso.CargarCadeteria("Data/cadeteria.csv", cadetes);
            CadeteriaService = new CadeteriaService(cadeteria);
        }
    }
}