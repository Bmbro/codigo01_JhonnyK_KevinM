using System.IO;

namespace MeteoAula.Cliente
{
    public class Entramar
    {
        // Lee del flujo byte a byte hasta encontrar el delimitador \n
        // Devuelve el mensaje completo sin el \n
        public static string LeerMensaje(Stream flujo)
        {
            byte[] buffer = new byte[1];
            string mensaje = "";

            while (true)
            {
                int leidos = flujo.Read(buffer, 0, 1);
                if (leidos == 0) return null;

                char c = (char)buffer[0];
                if (c == '\n') return mensaje;
                mensaje += c;
            }
        }
    }
}
