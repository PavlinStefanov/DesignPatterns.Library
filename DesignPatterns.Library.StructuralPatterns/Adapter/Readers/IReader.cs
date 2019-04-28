using System.Collections.Generic;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Readers
{
    public interface IReader
    {
        /// <summary>
        /// Collection property, which will store source resources
        /// </summary>
        IList<IModel> Resources { get; }

        /// <summary>
        /// Method that allows to read from specific source
        /// </summary>
        void Read();
    }
}
