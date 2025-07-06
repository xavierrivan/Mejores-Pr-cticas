using DesignPatterns.ModelBuilders;
using DesignPatterns.Models;

namespace DesignPatterns.Factories
{
    /// <summary>
    /// Factory para crear Ford Explorer
    /// </summary>
    public class FordExplorerFactory : CarFactory
    {
        public override Vehicle Created()
        {
            return new CarModelBuilder()
                .setModel("Explorer")
                .Build();
        }
    }
}
