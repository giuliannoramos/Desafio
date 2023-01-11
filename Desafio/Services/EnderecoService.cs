using AutoMapper;
using Desafio.Dtos;
using Desafio.Interfaces;

namespace Desafio.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper _mapper;
        private readonly IViacepApi _viacepApi;

        public EnderecoService(IMapper mapper, IViacepApi viacepApi)
        {
            _mapper = mapper;
            _viacepApi = viacepApi;
        }

        public async Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep)
        {
            var endereco = await _viacepApi.BuscarEnderecoPorCep(cep);

            return _mapper.Map<ResponseGenerico<EnderecoResponse>>(endereco);
        }
       
    }
}
