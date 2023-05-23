using Desafio.Dtos;
using Desafio.Interfaces;
using Desafio.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Dynamic;

namespace Desafio.Rest
{
    public class ViacepApiRest : IViacepApi
    {
        public async Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoPorCep(string cep)
        {
            // Criação da requisição HTTP GET para a API do ViaCEP
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://viacep.com.br/ws/{cep}/json/");

            var response = new ResponseGenerico<EnderecoModel>();

            using (var client = new HttpClient())
            {
                // Envio da requisição para a API do ViaCEP
                var responseViacepApi = await client.SendAsync(request);

                // Leitura do conteúdo da resposta
                var contentResp = await responseViacepApi.Content.ReadAsStringAsync();

                // Desserialização do conteúdo da resposta em um objeto EnderecoModel
                var objResponse = JsonSerializer.Deserialize<EnderecoModel>(contentResp);

                if (responseViacepApi.IsSuccessStatusCode)
                {
                    // Configuração da resposta de sucesso
                    response.CodigoHttp = responseViacepApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    // Configuração da resposta de erro
                    response.CodigoHttp = responseViacepApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }

            return response;
        }
    }
}