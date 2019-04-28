using System.Data;
using System.Data.SqlClient;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Client
{
    public class BulkOperations
    {
        private readonly DataSet _adapterSet;

        public BulkOperations(DataSet adapterSet)
        {
            _adapterSet = adapterSet;
        }

        public void PersistData()
        {
            using (SqlConnection connection = new SqlConnection(""))
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                    {
                        foreach (DataTable table in _adapterSet.Tables)
                        {
                            bulkCopy.DestinationTableName = table.TableName;
                            bulkCopy.WriteToServer(table);
                        }
                    }
                }
            }
        }
    }
}
