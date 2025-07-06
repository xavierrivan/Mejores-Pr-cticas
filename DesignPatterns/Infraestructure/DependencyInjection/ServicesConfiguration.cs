using DesignPatterns.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Infraestructure.DependencyInjection
{
    /// <summary>
    /// Configuración de servicios para inyección de dependencias
    /// </summary>
    public class ServicesConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Usar DBVehicleRepository al integrar Base de datos
            //services.AddTransient<IVehicleRepository, DBVehicleRepository>();
            services.AddTransient<IVehicleRepository, MyVehiclesRepository>();
        }
    }
}
