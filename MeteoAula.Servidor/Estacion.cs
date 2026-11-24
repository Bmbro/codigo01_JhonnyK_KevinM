using System.Collections.Generic;

namespace MeteoAula.Servidor
{
    public class Estacion
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public List<Lectura> Lecturas { get; set; }
    }
}
