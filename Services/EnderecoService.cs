using Desafio.Dtos;
using Desafio.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using AutoMapper;

namespace Desafio.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper _mapper;
        private readonly IViacepApi _viacepApi;
        private readonly IMemoryCache _cache;

        public EnderecoService(IMapper mapper, IViacepApi viacepApi, IMemoryCache cache)
        {
            _mapper = mapper;
            _viacepApi = viacepApi;
            _cache = cache;
        }

        public async Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep)
        {
            var cacheKey = $"endereco_{cep}";

            // Verifica se os dados estão em cache
            if (_cache.TryGetValue(cacheKey, out ResponseGenerico<EnderecoResponse> enderecoCache))
            {
                // Os dados estão em cache, define a fonte como "Cache" e retorna os dados
                enderecoCache.FonteDados = "Cache";
                return enderecoCache;
            }

            // Os dados não estão em cache, faz a busca na API do ViaCEP
            var enderecoViaCep = await _viacepApi.BuscarEnderecoPorCep(cep);

            // Mapeia o objeto de retorno para o tipo desejado
            var enderecoResponse = _mapper.Map<ResponseGenerico<EnderecoResponse>>(enderecoViaCep);

            // Define as opções de cache para 1 hora de expiração
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            };

            // Armazena os dados no cache
            _cache.Set(cacheKey, enderecoResponse, cacheOptions);

            // Define a fonte como "ViaCEP" e retorna os dados
            enderecoResponse.FonteDados = "ViaCEP";
            return enderecoResponse;
        }
    }
}