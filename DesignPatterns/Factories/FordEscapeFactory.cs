using DesignPatterns.ModelBuilders;
using DesignPatterns.Models;

namespace DesignPatterns.Factories
{
    /// <summary>
    /// Factory para crear Ford Escape
    /// </summary>
    public class FordEscapeFactory : CarFactory
    {
        public override Vehicle Created()
        {
            return new CarModelBuilder()
                .setModel("Escape")
                .Build();
        }
    }
}
