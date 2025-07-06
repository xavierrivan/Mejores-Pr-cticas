﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Models
{
    /// <summary>
    /// Clase base abstracta para todos los vehículos
    /// </summary>
    public abstract class Vehicle : IVehicle
    {
        #region Private properties
        private bool _isEngineOn { get; set; }
        #endregion

        #region Properties
        public readonly Guid ID;
        public virtual int Tires { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Gas { get; set; }
        public double FuelLimit { get; set; }
        public int Year { get; set; }

        #endregion

        #region Constructors

        public Vehicle(string color, string brand, string model, int year, double fuelLimit = 10)
        {
            ID = Guid.NewGuid();
            Color = color;
            Brand = brand;
            Model = model;
            FuelLimit = fuelLimit;
            Year = year;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Agrega combustible al vehículo
        /// </summary>
        public void AddGas()
        {
            if(Gas <= FuelLimit)
            {
                Gas += 0.1;
            }
            else
            {
                throw new Exception("Gas Full");
            }
        }
        
        /// <summary>
        /// Inicia el motor del vehículo
        /// </summary>
        public void StartEngine()
        {
            if (_isEngineOn)
            {
                throw new Exception("Engine is already on");
            }
            if (NeedsGas())
            {
                throw new Exception("No enoguht gas. You need to go to Gas Station");
            }
            _isEngineOn = true;
        }

        public bool NeedsGas()
        {
            return !(Gas > 0);
        }

        public bool IsEngineOn()
        {
            return _isEngineOn;
        }

        public void StopEngine()
        {
            if (!_isEngineOn)
            {
                throw new Exception("Enigne already stopped");
            }

            _isEngineOn = false;
        }

        #endregion

    }
}
