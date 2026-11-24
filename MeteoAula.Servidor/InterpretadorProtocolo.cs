using System.Collections.Generic;

namespace MeteoAula.Servidor
{
    public enum EstadoConexion
    {
        CONECTADO,
        IDENTIFICADO,
        CONSULTAS,
        CERRADO
    }

    public class InterpretadorProtocolo
    {
        private ServicioConsultas servicio;
        private EstadoConexion estado;

        public InterpretadorProtocolo()
        {
            servicio = new ServicioConsultas();
            estado = EstadoConexion.CONECTADO;
        }

        public bool Cerrado()
        {
            return estado == EstadoConexion.CERRADO;
        }

        public string ProcesarMensaje(string mensaje)
        {
            mensaje = mensaje.Trim();
            string[] partes = mensaje.Split('|');
            string comando = partes[0].ToUpper();

            // HELP disponible en cualquier estado
            if (comando == "HELP")
                return "200|OK|Comandos: HELLO, LIST, CURRENT, HISTORY, SUMMARY, HELP, QUIT";

            // QUIT disponible en cualquier estado
            if (comando == "QUIT")
            {
                estado = EstadoConexion.CERRADO;
                return "200|OK|Hasta luego";
            }

            if (estado == EstadoConexion.CONECTADO)
            {
                if (comando == "HELLO")
                {
                    if (partes.Length < 3)
                        return "400|ERROR|Formato incorrecto. Use: HELLO|version|identificador";

                    string version = partes[1];
                    if (version != "1")
                        return "401|ERROR|Version de protocolo no soportada";

                    estado = EstadoConexion.IDENTIFICADO;
                    return "200|OK|Bienvenido al servidor MeteoAula";
                }
                else
                {
                    return "402|ERROR|Debe iniciar con HELLO";
                }
            }

            if (estado == EstadoConexion.IDENTIFICADO || estado == EstadoConexion.CONSULTAS)
            {
                if (comando == "HELLO")
                    return "402|ERROR|Ya se identifico";

                if (comando == "LIST")
                {
                    estado = EstadoConexion.CONSULTAS;
                    List<Estacion> estaciones = servicio.ListarEstaciones();
                    string respuesta = "210|COUNT|" + estaciones.Count + "\n";
                    foreach (Estacion e in estaciones)
                        respuesta += "211|" + e.Codigo + "|" + e.Nombre + "|" + e.Ciudad + "\n";
                    respuesta += "212|END";
                    return respuesta;
                }

                if (comando == "CURRENT")
                {
                    if (partes.Length < 3)
                        return "500|ERROR|Formato incorrecto. Use: CURRENT|version|codigo";

                    string codigo = partes[2];
                    Lectura l = servicio.ObtenerActual(codigo);
                    if (l == null)
                        return "501|ERROR|Estacion no encontrada";

                    estado = EstadoConexion.CONSULTAS;
                    return "200|OK|" + codigo + "|" +
                           l.Fecha.ToString("yyyy-MM-dd") + "|" +
                           l.Fecha.ToString("HH:mm") + "|" +
                           l.Temperatura + "|" +
                           l.Humedad + "|" +
                           l.Estado;
                }

                if (comando == "HISTORY")
                {
                    if (partes.Length < 3)
                        return "500|ERROR|Formato incorrecto. Use: HISTORY|version|codigo";

                    string codigo = partes[2];
                    List<Lectura> lecturas = servicio.ObtenerHistorial(codigo);
                    if (lecturas == null)
                        return "501|ERROR|Estacion no encontrada";

                    estado = EstadoConexion.CONSULTAS;
                    string respuesta = "210|COUNT|" + lecturas.Count + "\n";
                    foreach (Lectura l in lecturas)
                        respuesta += "211|" +
                                     l.Fecha.ToString("yyyy-MM-dd") + "|" +
                                     l.Fecha.ToString("HH:mm") + "|" +
                                     l.Temperatura + "|" +
                                     l.Humedad + "|" +
                                     l.Estado + "\n";
                    respuesta += "212|END";
                    return respuesta;
                }

                if (comando == "SUMMARY")
                {
                    if (partes.Length < 3)
                        return "500|ERROR|Formato incorrecto. Use: SUMMARY|version|codigo";

                    string codigo = partes[2];
                    string resumen = servicio.ObtenerResumen(codigo);
                    if (resumen == null)
                        return "501|ERROR|Estacion no encontrada";

                    estado = EstadoConexion.CONSULTAS;
                    return "200|OK|" + codigo + "|" + resumen;
                }

                return "502|ERROR|Comando desconocido";
            }

            return "502|ERROR|Comando desconocido";
        }
    }
}







