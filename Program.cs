namespace Desafio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar serviços e pipeline de middleware
            var startup = new Startup();
            startup.ConfigureServices(builder.Services);
            var app = builder.Build();
            startup.Configure(app, app.Environment);

            app.Run();
        }
    }
}  
