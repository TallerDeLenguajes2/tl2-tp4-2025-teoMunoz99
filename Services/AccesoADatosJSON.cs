using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Clases;
using Interfaces;

public class AccesoADatosJSON : IAccesoADatos
{
    public List<Cadete> CargarCadetes(string _ruta)
    {
        try
        {
            if (!File.Exists(_ruta))
            {
                throw new FileNotFoundException($"Archivo no encontrado: {_ruta}");
            }

            string jsonContent = File.ReadAllText(_ruta);
            var cadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonContent);
            
            return cadetes ?? new List<Cadete>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar cadetes desde JSON: {ex.Message}");
            return new List<Cadete>();
        }
    }

    public Cadeteria CargarCadeteria(string _ruta, List<Cadete> _cadetes)
    {
        try
        {
            if (!File.Exists(_ruta))
            {
                throw new FileNotFoundException($"Archivo no encontrado: {_ruta}");
            }

            string jsonContent = File.ReadAllText(_ruta);
            var cadeteriaData = JsonSerializer.Deserialize<CadeteriaData>(jsonContent);
            
            if (cadeteriaData == null)
            {
                throw new Exception("Formato inválido del archivo JSON de cadetería");
            }

            return new Cadeteria(cadeteriaData.Nombre, cadeteriaData.Telefono, _cadetes);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar cadetería desde JSON: {ex.Message}");
            return new Cadeteria("Cadetería Default", 0, _cadetes);
        }
    }

    // clase aux para deserializar la vcadetería
    private class CadeteriaData
    {
        public string Nombre { get; set; }
        public int Telefono { get; set; }
    }
}