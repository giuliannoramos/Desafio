# Desafio: Web API de Consulta de Endereço por CEP

Este desafio consiste em uma Web API desenvolvida em C# utilizando o framework .NET Core 6. O objetivo da API é receber um CEP como parâmetro e retornar um endereço completo com base no CEP fornecido, consumindo os dados da API pública do ViaCEP (https://viacep.com.br/).

## Requisitos

- [.NET Core 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) ou uma versão superior.
- Editor de código ou IDE de sua preferência, como o Visual Studio Code, Visual Studio, etc.

## Configuração

1. Clone este repositório em sua máquina local.
2. Abra o projeto em seu editor de código ou IDE.
3. Verifique se você possui o .NET Core 6 SDK ou superior instalado.
4. Restaure as dependências do projeto executando o comando `dotnet restore` no diretório raiz do projeto.

## Uso

1. Execute a aplicação pressionando `F5` ou através do comando `dotnet run` no diretório raiz do projeto.
2. A API estará disponível na URL `https://localhost:7033` (ou em outra porta, dependendo da configuração).
3. Você pode testar a API usando o Swagger ou o Postman.

### Swagger

- Abra o seguinte URL em seu navegador: `https://localhost:7033/swagger`
- Use a interface do Swagger para enviar uma solicitação GET para a rota `/api/Endereco/busca/{cep}`, substituindo `{cep}` pelo CEP que deseja consultar.
- A resposta será um objeto JSON contendo o endereço completo correspondente ao CEP fornecido.

### Postman

- Abra o Postman ou qualquer cliente de API que preferir.
- Crie uma solicitação GET para a URL `https://localhost:7033/api/Endereco/busca/{cep}`, substituindo `{cep}` pelo CEP desejado.
- Envie a solicitação e você receberá uma resposta com o endereço completo correspondente ao CEP fornecido.

## Observações

- A entrada do CEP é validada para aceitar apenas `8 caracteres numéricos`.
- Certifique-se de que sua máquina tenha acesso à Internet para que a API possa consumir os dados do ViaCEP.

## Implementação do Cache em Memória

Para realizar essa implementação, foi utilizado o recurso IMemoryCache fornecido pelo framework .NET Core. Esse serviço permite armazenar objetos em memória por um período determinado, facilitando o acesso aos dados sem a necessidade de consultas adicionais à API externa.

Quando a API recebe uma solicitação de busca por um CEP, a lógica de consulta segue os seguintes passos:

1. Primeiro, verifica-se se o endereço correspondente ao CEP está presente no cache em memória.
2. Se o endereço estiver presente no cache, ele é retornado imediatamente, indicando que foi obtido do cache.
3. Caso contrário, é feita uma chamada à API do ViaCEP para obter o endereço.
4. O endereço obtido é armazenado no cache em memória para consultas futuras, com um tempo de expiração determinado.
5. Por fim, o endereço é retornado como resposta da consulta, indicando que foi obtido diretamente do ViaCEP.

Essa lógica permite que as consultas seguintes para o mesmo CEP sejam atendidas diretamente pelo cache, evitando chamadas adicionais à API externa. Isso resulta em um melhor desempenho da API, reduzindo o tempo de resposta, melhorando a experiência do usuário e diminuindo a carga no sistema.

## Conclusão

Esta Web API foi desenvolvida como um projeto de estudo pessoal, com o objetivo de demonstrar a criação de uma API simples que consome dados de uma API externa, utilizando um recurso de cache em memória para melhorar o desempenho.

Fique à vontade para explorar o código-fonte fornecido e entender o funcionamento da API. Se surgirem dúvidas, problemas ou se tiver sugestões de melhoria, não hesite em entrar em contato.
