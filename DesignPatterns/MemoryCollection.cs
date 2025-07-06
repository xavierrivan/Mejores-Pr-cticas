using DesignPatterns.Models;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;


namespace DesignPatterns
{
    /// <summary>
    /// Implementación del patrón Singleton para almacenamiento en memoria
    /// </summary>
    public class MemoryCollection
    {
        private static MemoryCollection _instace;
        public ICollection<Vehicle> Vehicles { get; set; }

        public MemoryCollection() 
        {
            Vehicles = new List<Vehicle>();
        }

        public static MemoryCollection Instance
        {
            get 
            {
                if(_instace == null)
                    _instace = new MemoryCollection();
                return _instace;
            }
        }
    }
}
