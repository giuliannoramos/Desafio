using Desafio.Dtos;
using Desafio.Models;
using System.Threading.Tasks;

namespace Desafio.Interfaces
{
    public interface IViacepApi
    {
        // Método para buscar um endereço por CEP
        Task<ResponseGenerico<EnderecoModel>> BuscarEnderecoPorCep(string cep);
    }
}