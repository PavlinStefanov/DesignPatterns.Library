using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Readers
{
    public class JsonfileReader : IReader
    {
        private readonly string _path;

        public JsonfileReader(string path)
        {
            _path = path;
            Resources = new List<IModel>();
        }

        public IList<IModel> Resources { get; private set; }

        public void Read()
        {
            using (StreamReader file = File.OpenText(_path))
            {
                JsonSerializer serializer = new JsonSerializer();
                var categories = serializer.Deserialize(file, typeof(IList<Category>));

                ((List<IModel>)Resources).AddRange((IList<Category>)categories);
            }
        }
    }
}
