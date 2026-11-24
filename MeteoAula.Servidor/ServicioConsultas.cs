using System;
using System.Collections.Generic;

namespace MeteoAula.Servidor
{
    public class ServicioConsultas
    {
        private Repositorio repositorio;

        public ServicioConsultas()
        {
            repositorio = new Repositorio();
        }

        public List<Estacion> ListarEstaciones()
        {
            return repositorio.ObtenerEstaciones();
        }

        public Lectura ObtenerActual(string codigo)
        {
            Estacion estacion = repositorio.ObtenerEstacion(codigo);
            if (estacion == null) return null;
            return estacion.Lecturas[estacion.Lecturas.Count - 1];
        }

        public List<Lectura> ObtenerHistorial(string codigo)
        {
            Estacion estacion = repositorio.ObtenerEstacion(codigo);
            if (estacion == null) return null;

            List<Lectura> lecturas = estacion.Lecturas;
            if (lecturas.Count > 24)
                return lecturas.GetRange(lecturas.Count - 24, 24);
            return lecturas;
        }

        public string ObtenerResumen(string codigo)
        {
            Estacion estacion = repositorio.ObtenerEstacion(codigo);
            if (estacion == null) return null;

            double min = estacion.Lecturas[0].Temperatura;
            double max = estacion.Lecturas[0].Temperatura;
            double suma = 0;

            foreach (Lectura l in estacion.Lecturas)
            {
                if (l.Temperatura < min) min = l.Temperatura;
                if (l.Temperatura > max) max = l.Temperatura;
                suma += l.Temperatura;
            }

            double promedio = suma / estacion.Lecturas.Count;
            return min + "|" + max + "|" + Math.Round(promedio, 1);
        }
    }
}
