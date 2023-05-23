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
2. A API estará disponível na URL `https://localhost:5001` (ou em outra porta, dependendo da configuração).
3. Você pode testar a API usando o Swagger ou o Postman.

### Swagger

- Abra o seguinte URL em seu navegador: `https://localhost:5001/swagger`
- Use a interface do Swagger para enviar uma solicitação GET para a rota `/api/cep/{cep}`, substituindo `{cep}` pelo CEP que deseja consultar.
- A resposta será um objeto JSON contendo o endereço completo correspondente ao CEP fornecido.

### Postman

- Abra o Postman ou qualquer cliente de API que preferir.
- Crie uma solicitação GET para a URL `https://localhost:5001/api/cep/{cep}`, substituindo `{cep}` pelo CEP desejado.
- Envie a solicitação e você receberá uma resposta com o endereço completo correspondente ao CEP fornecido.

## Observações

- A entrada do CEP é validada para aceitar apenas `8 caracteres numéricos`.
- Certifique-se de que sua máquina tenha acesso à Internet para que a API possa consumir os dados do ViaCEP.

## Conclusão

Esta Web API foi desenvolvida como um projeto de estudo pessoal para demonstrar a criação de uma API simples que consome dados de uma API externa. Sinta-se à vontade para explorar o código-fonte fornecido. Caso tenha dúvidas, problemas ou sugestões de melhoria, não hesite em entrar em contato.
