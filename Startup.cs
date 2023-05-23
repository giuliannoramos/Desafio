using Desafio.Interfaces;
using Desafio.Mappings;
using Desafio.Rest;
using Desafio.Services;
using Microsoft.OpenApi.Models;

namespace Desafio
{
    public class Startup
    {
        // Configuração dos serviços
        public void ConfigureServices(IServiceCollection services)
        {
            // Adicionar suporte a controllers
            services.AddControllers();

            // Adicionar documentação do Swagger/OpenAPI
            services.AddSwaggerGen(c =>
            {
                // Configurar informações básicas do Swagger
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio API", Version = "v1" });
            });

            // Adicionar serviços personalizados
            services.AddSingleton<IEnderecoService, EnderecoService>();  // Registrar o serviço EnderecoService
            services.AddSingleton<IViacepApi, ViacepApiRest>();  // Registrar o serviço ViacepApiRest

            // Registrar o serviço IMemoryCache
            services.AddMemoryCache();

            // Configurar mapeamento de objetos usando AutoMapper
            services.AddAutoMapper(typeof(EnderecoMapping));  // Registrar o mapeamento EnderecoMapping
        }

        // Configuração do pipeline de requisição
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Verificar se o ambiente é de desenvolvimento
            if (env.IsDevelopment())
            {
                // Adicionar middleware do Swagger
                app.UseSwagger();

                // Configurar a interface do Swagger UI
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio API v1");
                });
            }

            // Redirecionar solicitações HTTP para HTTPS
            app.UseHttpsRedirection();

            // Roteamento das solicitações
            app.UseRouting();

            // Adicionar autorização
            app.UseAuthorization();

            // Configurar os endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  // Mapear controllers
            });
        }
    }
}
