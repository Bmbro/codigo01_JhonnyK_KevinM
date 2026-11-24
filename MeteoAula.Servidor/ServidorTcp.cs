using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MeteoAula.Servidor
{
    public class ServidorTcp
    {
        public void Iniciar(int puerto)
        {
            TcpListener oyente = new TcpListener(IPAddress.Any, puerto);
            oyente.Start();
            Console.WriteLine("Servidor escuchando en puerto " + puerto);

            while (true)
            {
                Console.WriteLine("Esperando cliente...");
                TcpClient cliente = oyente.AcceptTcpClient();
                Console.WriteLine("Cliente conectado.");

                NetworkStream flujo = cliente.GetStream();
                InterpretadorProtocolo interpretador = new InterpretadorProtocolo();

                // Enviar bienvenida
                string bienvenida = "100|HELLO|MeteoAula|1\n";
                byte[] bytesBienvenida = Encoding.ASCII.GetBytes(bienvenida);
                flujo.Write(bytesBienvenida, 0, bytesBienvenida.Length);

                while (!interpretador.Cerrado())
                {
                    string mensajeRecibido = LeerMensaje(flujo);
                    if (mensajeRecibido == null) break;

                    Console.WriteLine("Recibido: " + mensajeRecibido);

                    string respuesta = interpretador.ProcesarMensaje(mensajeRecibido);
                    string respuestaConDelimitador = respuesta + "\n";
                    byte[] bytesRespuesta = Encoding.ASCII.GetBytes(respuestaConDelimitador);
                    flujo.Write(bytesRespuesta, 0, bytesRespuesta.Length);

                    Console.WriteLine("Enviado: " + respuesta);
                }

                cliente.Close();
                Console.WriteLine("Cliente desconectado.");
            }
        }

        private string LeerMensaje(NetworkStream flujo)
        {
            // Lee byte a byte hasta encontrar \n
            byte[] buffer = new byte[1];
            string mensaje = "";

            try
            {
                while (true)
                {
                    int leidos = flujo.Read(buffer, 0, 1);
                    if (leidos == 0) return null;

                    char c = (char)buffer[0];
                    if (c == '\n') return mensaje;
                    mensaje += c;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
