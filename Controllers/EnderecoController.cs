using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Desafio.Dtos;
using Desafio.Interfaces;
using System.Threading.Tasks;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService; // Injeta a dependência do serviço de endereço no construtor
        }

        [HttpGet("busca/{cep}")]
        public async Task<IActionResult> BuscarEndereco([FromRoute][RegularExpression(@"^\d{8}$")] string cep)
        {
            var response = await _enderecoService.BuscarEndereco(cep); // Chama o serviço para buscar o endereço com base no CEP

            if (response.DadosRetorno != null)
            {
                return Ok(response); // Retorna a resposta completa do serviço
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NotFound); // Retorna o código de status HTTP 404 Not Found
            }
        }
    }
}