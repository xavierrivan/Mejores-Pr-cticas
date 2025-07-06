using DesignPatterns.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Repositories
{
    /// <summary>
    /// Interfaz del repositorio para operaciones CRUD de vehículos
    /// </summary>
    public interface IVehicleRepository
    {
        ICollection<Vehicle> GetVehicles();

        void AddVehicle(Vehicle vehicle);

        Vehicle Find(string id);

    }
}
