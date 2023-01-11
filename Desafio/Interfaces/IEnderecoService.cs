using Desafio.Dtos;

namespace Desafio.Interfaces
{
    public interface IEnderecoService
    {
        Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep);     
    }
}
