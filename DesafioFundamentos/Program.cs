using DesafioEstacionamento.Models;
using DesafioEstacionamento.Services;

namespace DesafionEstacionamento
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var service = new EstacionamentoService(new Estacionamento());

            service.IniciarEstacionamento();
        }
    }
}