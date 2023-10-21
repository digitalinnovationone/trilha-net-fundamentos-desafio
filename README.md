
# Desafio Fundamentos

Um projeto que simula um sistema de gerenciamento de um estacionamento feito com o intuito de ser submetido à um desafio do bootcamp Programação C# com CRM Dynamics feito pela DIO:
https://www.dio.me/bootcamp/coding-future-avanade-programacao-c-com-crm-dynamics



## Melhorias

No desafio, foi pedido algumas melhorias no código, tais como:

-AO INCLUIR UM VEÍCULO-
* Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos".
Para essa parte, eu criei uma verificação com Regex utilizando os dois padrões de placas brasileiras que existem atualmente (XXX-1111 ou XXX1X11). Caso a condição seja aceita, o sistema adiciona a placa na lista de veículos.

-AO EXCLUIR UM VEÍCULO-
* Pedir para o usuário digitar a placa e armazenar na variável placa.
* Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado.
* Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal.
* Remover a placa digitada da lista de veículos
Nessa parte, após armazenar a placa do veículo e fazer a verificação se o mesmo está dentro do estacionamento, criei uma solicitação para o usuário inserir a quantidade de horas que o veículo permaneceu estacionado, e também uma validação para saber se o valor digitado é realmente um número (utilizando TryParse). Caso as condições forem aceitas, o sistema remove a placa da lista de veículos.

-AO LISTAr TODOS OS VEÍCULOS-
* Realizar um laço de repetição, exibindo os veículos estacionados.
Nesse ultimo passo, criei uma verificação se existe algum veículo na lista (usando .Any())
Caso não tenha, é exibido uma mensagem de que o estacionamento está vazio.
Caso tenha, um laço (foreach) imprime todos os veículos da lista no console.

