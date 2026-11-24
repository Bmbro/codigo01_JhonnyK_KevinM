using System;
using System.Net.Sockets;
using System.Text;

namespace MeteoAula.Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Conectando al servidor MeteoAula...");

            TcpClient cliente = new TcpClient("127.0.0.1", 5000);
            NetworkStream flujo = cliente.GetStream();

            Console.WriteLine("Conectado. Escribe los comandos (ej: HELLO|1|Cliente01)");
            Console.WriteLine("Para salir escribe: QUIT|1|Cliente01");
            Console.WriteLine();

            // Leer bienvenida del servidor
            string bienvenida = Entramar.LeerMensaje(flujo);
            Console.WriteLine("Servidor: " + bienvenida);

            while (true)
            {
                Console.Write("Tu comando: ");
                string comando = Console.ReadLine();

                if (comando == null || comando.Trim() == "") continue;

                // Enviar comando con \n al final
                string comandoConDelimitador = comando + "\n";
                byte[] bytes = Encoding.ASCII.GetBytes(comandoConDelimitador);
                flujo.Write(bytes, 0, bytes.Length);

                // Leer respuesta(s)
                string linea = Entramar.LeerMensaje(flujo);
                Console.WriteLine("Servidor: " + linea);

                if (linea != null && linea.StartsWith("210"))
                {
                    // Respuesta multi-registro: leer hasta 212|END
                    while (true)
                    {
                        string lineaSig = Entramar.LeerMensaje(flujo);
                        Console.WriteLine("Servidor: " + lineaSig);
                        if (lineaSig == null || lineaSig.StartsWith("212")) break;
                    }
                }

                // Si el usuario escribio QUIT, salir
                if (comando.ToUpper().StartsWith("QUIT")) break;
            }

            cliente.Close();
            Console.WriteLine("Conexion cerrada.");
        }
    }
}
