using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    /// <summary>
    /// Implementación específica de un automóvil
    /// </summary>
    public class Car : Vehicle
    {
        public override int Tires { get => 4; }

        public Car(string color, string brand, string model, int year) : base(color, brand, model,year)
        {

        }
    }
}
