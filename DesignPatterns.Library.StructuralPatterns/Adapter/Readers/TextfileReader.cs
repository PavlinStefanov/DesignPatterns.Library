using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Readers
{
    public class TextfileReader : IReader
    {
        private const int BufferSize = 128;
        private const char Delimiter = ',';
        private readonly string _path;

        public TextfileReader(string path)
        {
            _path = path;
            Resources = new List<IModel>();
        }

        public IList<IModel> Resources { get; private set; }

        /// <summary>
        /// https://stackoverflow.com/questions/8037070/whats-the-fastest-way-to-read-a-text-file-line-by-line
        /// http://software-pattern.org/
        /// </summary>
        public void Read()
        {
            using (var fileStream = File.OpenRead(_path))
            using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    string[] irisLineToArray = line.Split(Delimiter);
                    var irisLine = TryMapIrisLine(irisLineToArray);

                    Resources.Add(irisLine);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderLine"></param>
        /// <returns></returns>
        private IrisModel TryMapIrisLine(string[] irisLine)
        {
            return new IrisModel
            {
                SepalLength = TryParse(irisLine[0]),
                SepalWidth = TryParse(irisLine[1]),
                PetalLength = TryParse(irisLine[2]),
                PetalWidth = TryParse(irisLine[3]),
                Class = irisLine[4]
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private double TryParse(string value)
        {
            try
            {
                return double.Parse(value);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to map value '{value}'.", ex);
            }
        }
    }
}
