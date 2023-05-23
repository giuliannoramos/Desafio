using Desafio.Dtos;
using System.Threading.Tasks;

namespace Desafio.Interfaces
{
    public interface IEnderecoService
    {
        // Método para buscar um endereço com base no CEP
        Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep);
    }
}