using System;
using System.Collections.Generic;

namespace MeteoAula.Servidor
{
    public class Repositorio
    {
        private List<Estacion> estaciones;

        public Repositorio()
        {
            estaciones = new List<Estacion>
            {
                new Estacion { Codigo = "EPN01", Nombre = "Estacion Central", Ciudad = "Quito", Lecturas = new List<Lectura>
                {
                    new Lectura { Fecha = new DateTime(2026,11,1,8,0,0),  Temperatura = 18.5, Humedad = 72, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,1,10,0,0), Temperatura = 20.1, Humedad = 65, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,2,8,0,0),  Temperatura = 17.3, Humedad = 80, Estado = "Lluvia" },
                    new Lectura { Fecha = new DateTime(2026,11,2,10,0,0), Temperatura = 19.0, Humedad = 70, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,8,0,0),  Temperatura = 21.2, Humedad = 60, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,10,0,0), Temperatura = 22.0, Humedad = 58, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,4,8,0,0),  Temperatura = 16.8, Humedad = 85, Estado = "Lluvia" },
                    new Lectura { Fecha = new DateTime(2026,11,4,10,0,0), Temperatura = 18.0, Humedad = 78, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,8,0,0),  Temperatura = 19.5, Humedad = 68, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,10,0,0), Temperatura = 20.8, Humedad = 63, Estado = "Soleado" }
                }},
                new Estacion { Codigo = "EPN02", Nombre = "Estacion Norte", Ciudad = "Quito", Lecturas = new List<Lectura>
                {
                    new Lectura { Fecha = new DateTime(2026,11,1,8,0,0),  Temperatura = 15.0, Humedad = 90, Estado = "Lluvia" },
                    new Lectura { Fecha = new DateTime(2026,11,1,10,0,0), Temperatura = 16.5, Humedad = 82, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,2,8,0,0),  Temperatura = 14.8, Humedad = 92, Estado = "Lluvia" },
                    new Lectura { Fecha = new DateTime(2026,11,2,10,0,0), Temperatura = 17.0, Humedad = 75, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,8,0,0),  Temperatura = 18.2, Humedad = 70, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,10,0,0), Temperatura = 19.5, Humedad = 65, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,4,8,0,0),  Temperatura = 13.5, Humedad = 95, Estado = "Lluvia" },
                    new Lectura { Fecha = new DateTime(2026,11,4,10,0,0), Temperatura = 15.8, Humedad = 88, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,8,0,0),  Temperatura = 17.3, Humedad = 73, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,10,0,0), Temperatura = 18.9, Humedad = 68, Estado = "Soleado" }
                }},
                new Estacion { Codigo = "EPN03", Nombre = "Estacion Sur", Ciudad = "Quito", Lecturas = new List<Lectura>
                {
                    new Lectura { Fecha = new DateTime(2026,11,1,8,0,0),  Temperatura = 20.0, Humedad = 55, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,1,10,0,0), Temperatura = 22.5, Humedad = 50, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,2,8,0,0),  Temperatura = 19.3, Humedad = 62, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,2,10,0,0), Temperatura = 21.0, Humedad = 57, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,8,0,0),  Temperatura = 23.1, Humedad = 48, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,10,0,0), Temperatura = 24.0, Humedad = 45, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,4,8,0,0),  Temperatura = 18.5, Humedad = 70, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,4,10,0,0), Temperatura = 20.2, Humedad = 63, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,8,0,0),  Temperatura = 22.0, Humedad = 52, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,10,0,0), Temperatura = 23.5, Humedad = 48, Estado = "Soleado" }
                }},
                new Estacion { Codigo = "GYE01", Nombre = "Estacion Puerto", Ciudad = "Guayaquil", Lecturas = new List<Lectura>
                {
                    new Lectura { Fecha = new DateTime(2026,11,1,8,0,0),  Temperatura = 28.0, Humedad = 85, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,1,10,0,0), Temperatura = 30.5, Humedad = 80, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,2,8,0,0),  Temperatura = 27.5, Humedad = 88, Estado = "Lluvia" },
                    new Lectura { Fecha = new DateTime(2026,11,2,10,0,0), Temperatura = 29.0, Humedad = 82, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,8,0,0),  Temperatura = 31.2, Humedad = 75, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,10,0,0), Temperatura = 32.0, Humedad = 70, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,4,8,0,0),  Temperatura = 26.8, Humedad = 90, Estado = "Lluvia" },
                    new Lectura { Fecha = new DateTime(2026,11,4,10,0,0), Temperatura = 28.5, Humedad = 86, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,8,0,0),  Temperatura = 30.0, Humedad = 78, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,10,0,0), Temperatura = 31.5, Humedad = 72, Estado = "Soleado" }
                }},
                new Estacion { Codigo = "CUE01", Nombre = "Estacion Tomebamba", Ciudad = "Cuenca", Lecturas = new List<Lectura>
                {
                    new Lectura { Fecha = new DateTime(2026,11,1,8,0,0),  Temperatura = 14.0, Humedad = 78, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,1,10,0,0), Temperatura = 16.5, Humedad = 70, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,2,8,0,0),  Temperatura = 13.2, Humedad = 85, Estado = "Lluvia" },
                    new Lectura { Fecha = new DateTime(2026,11,2,10,0,0), Temperatura = 15.0, Humedad = 75, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,8,0,0),  Temperatura = 17.3, Humedad = 65, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,3,10,0,0), Temperatura = 18.5, Humedad = 60, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,4,8,0,0),  Temperatura = 12.8, Humedad = 90, Estado = "Lluvia" },
                    new Lectura { Fecha = new DateTime(2026,11,4,10,0,0), Temperatura = 14.5, Humedad = 82, Estado = "Nublado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,8,0,0),  Temperatura = 16.0, Humedad = 72, Estado = "Soleado" },
                    new Lectura { Fecha = new DateTime(2026,11,5,10,0,0), Temperatura = 17.8, Humedad = 67, Estado = "Soleado" }
                }}
            };
        }

        public List<Estacion> ObtenerEstaciones()
        {
            return estaciones;
        }

        public Estacion ObtenerEstacion(string codigo)
        {
            foreach (Estacion e in estaciones)
            {
                if (e.Codigo == codigo)
                    return e;
            }
            return null;
        }
    }
}
