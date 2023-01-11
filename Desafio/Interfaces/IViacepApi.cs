using Desafio.Dtos;
using Desafio.Models;

namespace Desafio.Interfaces
{
    public interface IViacepApi
    {
        Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoPorCep(string cep);
    }
}
