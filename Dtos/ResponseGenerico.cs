using System.Dynamic;
using System.Net;

namespace Desafio.Dtos
{
    public class ResponseGenerico<T> where T : class
    {
        // Propriedade que representa o código de status HTTP da resposta
        public HttpStatusCode CodigoHttp { get; set; }

        // Propriedade que armazena os dados de retorno
        public T? DadosRetorno { get; set; }

        // Propriedade que armazena os erros de retorno
        public ExpandoObject? ErroRetorno { get; set; }

        // Propriedade para indicar a fonte dos dados (ViaCEP ou cache)
        public string? FonteDados { get; set; }
    }
}