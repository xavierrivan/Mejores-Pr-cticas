using DesignPatterns.Models;

namespace DesignPatterns.Factories
{
    /// <summary>
    /// Clase abstracta base para el patrón Factory Method
    /// </summary>
    public abstract class CarFactory
    {
        public abstract Vehicle Created();
    }
}
