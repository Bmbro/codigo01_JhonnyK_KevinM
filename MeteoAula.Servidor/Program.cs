namespace MeteoAula.Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            ServidorTcp servidor = new ServidorTcp();
            servidor.Iniciar(5000);
        }
    }
}
