using DesignPatterns.Models;
using System;

namespace DesignPatterns.ModelBuilders
{
    /// <summary>
    /// Builder para construir vehículos con propiedades por defecto
    /// </summary>
    public class CarModelBuilder
    {
        private string color = "red";
        private string brand = "Ford";
        private string model = "F150";
        private int year = DateTime.Now.Year;

        public CarModelBuilder setColor( string color) 
        {
            this.color = color;
            return this;
        }

        public CarModelBuilder setBrand(string brand)
        {
            this.brand = brand;
            return this;
        }

        public CarModelBuilder setModel(string model)
        {
            this.model = model;
            return this;
        }
        public CarModelBuilder setYear(int year)
        {
            this.year = year;
            return this;
        }

        /// <summary>
        /// Construye y retorna el vehículo con las propiedades configuradas
        /// </summary>
        public Vehicle Build()
        {
            return new Car(color, brand, model, year);
        }

    }
}
