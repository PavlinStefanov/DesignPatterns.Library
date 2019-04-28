using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Adapters
{
    public class AdaptersHandler : IAdapterHandler<IDataSourceAdapter, DataSet>
    {

        public void Handle(IDataSourceAdapter adapter, DataSet adapterSet)
        {
            adapter.Fill(adapterSet);
        }

        /// <summary>
        /// Method which allows to process collection of adapters
        /// </summary>
        /// <param name="adapters"></param>
        /// <param name="adapterSet"></param>
        public void HandleAll(IList<IDataSourceAdapter> adapters, DataSet adapterSet)
        {
            adapters.ToList().ForEach(adapter =>
            {
                Handle(adapter, adapterSet);
            });
        }
    }
}
