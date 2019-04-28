using DesignPatterns.Library.StructuralPatterns.Adapter.Adapters;
using DesignPatterns.Library.StructuralPatterns.Adapter.Readers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace DesignPatterns.Library.CClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet adapterSet = new DataSet();

            string path = GetLocation(@"Data\iris.txt");
            string jsonPath = GetLocation(@"Data\categories.json");
            string xmlPath = GetLocation(@"Data\employees.xml");

            var xmlReader = new XmlfileReader(xmlPath);
            var xmlAdapter = new XmlfileAdapter(xmlReader);

            var jsonReader = new JsonfileReader(jsonPath);
            var jsonAdapter = new JsonfileAdapter(jsonReader);

            var textReader = new TextfileReader(path);
            var textAdapter = new TextfileAdapter(textReader);

            var adapters = new List<IDataSourceAdapter>();
            adapters.Add(textAdapter);
            adapters.Add(jsonAdapter);
            adapters.Add(xmlAdapter);

            var handler = new AdaptersHandler();
            //handler.Handle(xmlAdapter, adapterSet);
            handler.HandleAll(adapters, adapterSet);

            PrintTable(adapterSet);
            //var bulkOperations = new BulkOperations(adapterSet);
            //bulkOperations.PersistData();
        }

        private static string GetLocation(string location)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @location);
        }

        private static void PrintTable(DataSet dataSet)
        {
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.Write(column.ColumnName.PadRight(20) + " ");
                }
                Console.WriteLine();
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        Console.Write(row[i].ToString().PadRight(20) + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
