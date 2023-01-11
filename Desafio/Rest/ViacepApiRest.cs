using Desafio.Dtos;
using Desafio.Interfaces;
using Desafio.Models;
using System.Dynamic;
using System.Text.Json;

namespace Desafio.Rest
{
    public class ViacepApiRest : IViacepApi
    {
        public async Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoPorCep(string cep)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://viacep.com.br/ws/{cep}/json/");

            var response = new ResponseGenerico<EnderecoModel>();
            using (var client = new HttpClient())
            {
                var responseViacepApi = await client.SendAsync(request);
                var contentResp = await responseViacepApi.Content.ReadAsStringAsync();
                var objResponse = JsonSerializer.Deserialize<EnderecoModel>(contentResp);

                if (responseViacepApi.IsSuccessStatusCode)
                {
                    response.CodigoHttp = responseViacepApi.StatusCode;
                    response.DadosRetorno = objResponse;
                }
                else
                {
                    response.CodigoHttp = responseViacepApi.StatusCode;
                    response.ErroRetorno = JsonSerializer.Deserialize<ExpandoObject>(contentResp);
                }
            }
            return response;
        }

       
    }
}
