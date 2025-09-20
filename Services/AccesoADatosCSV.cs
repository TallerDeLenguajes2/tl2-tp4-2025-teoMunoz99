using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Clases;
using Interfaces;

public class AccesoADatosCSV : IAccesoADatos
{
    public List<Cadete> CargarCadetes(string _ruta)
    {
        try
        {
            if (!File.Exists(_ruta))
            {
                throw new FileNotFoundException($"Archivo no encontrado: {_ruta}");
            }

            return File.ReadLines(_ruta)
                        .Skip(1) // Salteo la primera linea que es la cabecera
                        .Select(linea =>
                        {
                            var datos = linea.Split(';');
                            if (datos.Length < 4)
                            {
                                throw new FormatException($"Línea con formato incorrecto: {linea}");
                            }
                            
                            string nombre = datos[1];
                            string direccion = datos[2];
                            int telefono = int.Parse(datos[3]);
                            return new Cadete(nombre, direccion, telefono);
                        })
                        .ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar cadetes desde CSV: {ex.Message}");
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

            var linea = File.ReadLines(_ruta).Skip(1).FirstOrDefault();
            if (string.IsNullOrEmpty(linea))
            {
                throw new Exception("Archivo de cadetería vacío o sin datos");
            }

            var datos = linea.Split(';');
            if (datos.Length < 2)
            {
                throw new FormatException($"Línea con formato incorrecto: {linea}");
            }

            string nombre = datos[0];
            int telefono = int.Parse(datos[1]);

            return new Cadeteria(nombre, telefono, _cadetes);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al cargar cadetería desde CSV: {ex.Message}");
            return new Cadeteria("Cadetería Default", 0, _cadetes);
        }
    }
}