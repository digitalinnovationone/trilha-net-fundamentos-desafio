# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar


## Solução
**AdicionarVeiculo**
- Foi implementado uma string "adicionaPlaca" no qual recebe a placa dos veículos que estão no estacionamento e adiciona os mesmos na lista "veiculos"
```csharp
    string adicionaPlaca = Console.ReadLine();
    veiculos.Add(adicionaPlaca);
```

**RemoverVeiculo**
- Adicionado um ReadLine a string "placa" para que pudesse receber a placa digitada pelo usúario.
```csharp
    string placa = Console.ReadLine();
```

- Adicionado um ReadLine a string "horas" para que pudesse receber a quantidade de horas digitada pelo usúario.
```csharp
    int horas = int.Parse(Console.ReadLine());
```  

- Na variavél "valorTotal" foi implementado o calculo para que ao remover o veículo mostrar pro usúario o valor que ficou a permanência do cliente no estacionamento.
```csharp
    decimal valorTotal = precoInicial + (precoPorHora * horas);
```

- Implementando função para remover o veículo da lista "veiculos" pegando pela string "placa".
```csharp
    veiculos.Remove(placa);
```

**ListarVeiculos**
- Adicionado laço foreach para percorrer por toda a lista e apresentasse para o usúario as placas cadastradas no sistema.
```csharp 
    foreach (string veiculo in veiculos)
    {
        Console.WriteLine(veiculo);   
    }
```
