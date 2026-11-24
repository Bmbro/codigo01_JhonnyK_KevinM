using System;

namespace MeteoAula.Servidor
{
    public class Lectura
    {
        public DateTime Fecha { get; set; }
        public double Temperatura { get; set; }
        public double Humedad { get; set; }
        public string Estado { get; set; }
    }
}
