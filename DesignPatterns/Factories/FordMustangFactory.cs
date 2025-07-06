using DesignPatterns.ModelBuilders;
using DesignPatterns.Models;

namespace DesignPatterns.Factories
{
    /// <summary>
    /// Factory para crear Ford Mustang
    /// </summary>
    public class FordMustangFactory : CarFactory
    {
        public override Vehicle Created()
        {
            return new CarModelBuilder()
                .setModel("Mustang")
                .Build();
        }
    }
}
