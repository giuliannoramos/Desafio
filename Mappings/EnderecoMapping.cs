using AutoMapper;
using Desafio.Dtos;
using Desafio.Models;

namespace Desafio.Mappings
{
    public class EnderecoMapping : Profile
    {
        public EnderecoMapping()
        {
            // Mapeamento entre tipos genéricos ResponseGenerico<>, mantendo a mesma estrutura
            CreateMap(typeof(ResponseGenerico<>), typeof(ResponseGenerico<>));

            // Mapeamento entre EnderecoResponse e EnderecoModel
            CreateMap<EnderecoResponse, EnderecoModel>();

            // Mapeamento entre EnderecoModel e EnderecoResponse
            CreateMap<EnderecoModel, EnderecoResponse>();
        }
    }
}