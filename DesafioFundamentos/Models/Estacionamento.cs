using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal PrecoInicial { get; set; }
        private decimal PrecoPorHora { get; set; }
        private List<string> _veiculos = new List<string>();


        public Estacionamento(decimal precoInicial)
        {
            this.PrecoInicial = precoInicial;
        }
        public Estacionamento(decimal precoInicial, decimal precoPorHora) : this(precoInicial)
        {
            this.PrecoPorHora = precoPorHora;
        }


        //====================== ADICIONAR ===============================


        public void AdicionarVeiculo()
        {

            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            Console.Write("Digite a placa do veículo para estacionar => [Ex: ABC1234]: ");
            string placaAddSistema = Console.ReadLine().ToUpper();


            if (ValidarPlaca(placaAddSistema))
            {
                _veiculos.Add(placaAddSistema);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("\nPlaca válida! Registrado no sistema...\n");

                int cont = 0;
                foreach (string value in _veiculos)
                {
                    cont++;
                    System.Console.WriteLine($"{cont}º Placa cadastrada: {value}");
                }

            }
            else
            {
                Console.WriteLine("\nPlaca inválida. Por favor, digite uma placa válida.");
                AdicionarVeiculo();
            }


        }


        //===================== PADRAO PLACA BRASIL =================
        public bool ValidarPlaca(string placa)
        {
            // Padrão de placa comum no Brasil: ABC1234 (3 letras, 4 número)
            string patternVeiculos = @"^[A-Za-z]{3}\d{4}$";

            // Verificar se a placa corresponde ao padrão
            return Regex.IsMatch(placa, patternVeiculos);
        }


        //================== REMOVER  =======================

        //CRIANDO UMA CÓPIA DE SERGURANÇA DA MINHA LISTA DE _VEICULOS           
        List<string> copiaMinhaListVeiculos;

        public void RemoverVeiculo()
        {
            //CHAMANDO MINHA CÓPIA DE SEGURANÇA
            copiaMinhaListVeiculos = new List<string>(_veiculos);

            if (copiaMinhaListVeiculos.Any())
            {
                // Pedir para o usuário digitar a placa e armazenar na variável placa
                Console.WriteLine("Digite a placa do veículo que você deseja remover:");
                Console.WriteLine();

                int cont = 0;
                foreach (string listacopia in copiaMinhaListVeiculos)
                {
                    cont++;
                    System.Console.WriteLine($"{cont}º Placa cadastrada: {listacopia}");
                }

                // *IMPLEMENTE AQUI*
                string placaRemover = Console.ReadLine().ToUpper();


                // Verifica se o veículo existe com o padrão q implementei de placa no método ValidarPlaca Ex: ABC1234
                if (ValidarPlaca(placaRemover) && copiaMinhaListVeiculos.Contains(placaRemover))
                {

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    Console.Clear();
                    Console.Write("Digite a quantidade de horas que o veículo permaneceu estacionado: ");

                    int horaDigitada = int.Parse(Console.ReadLine());
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    decimal valorTotal = (PrecoInicial + PrecoPorHora) * horaDigitada;



                    _veiculos.Remove(placaRemover);


                    System.Console.WriteLine($"A placa {placaRemover} e seu valor total foi R${valorTotal:F2} foi removida com sucesso!\nObrigado por usar nosso Sistema. ");

                }
                else
                {
                    System.Console.WriteLine($"Desculpe-me, mas esta placa, <{placaRemover}>, não consta em nosso cadastro.\nTente novamente. Obrigado");
                    RemoverVeiculo();
                }

            }
        }



        //=================== LISTAR =====================
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (_veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                int cont=0;
                foreach (string valueLista in _veiculos)
                {
                    cont++;
                    System.Console.WriteLine($"{cont}º Veículo: {valueLista}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

    }
}
