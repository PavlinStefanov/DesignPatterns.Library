using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DesignPatterns.Library.StructuralPatterns.Adapter.Readers
{
    public class XmlfileReader : IReader
    {
        private readonly string _path;

        public XmlfileReader(string path)
        {
            _path = path;
            Resources = new List<IModel>();
        }

        public IList<IModel> Resources { get; private set; }

        public void Read()
        {
            var xml = XDocument.Load(_path);

            var employeeQuery = (from c in xml.Root.Descendants("Employee")
                                 select new EmployeeXmlMapper
                                 {
                                     FirstName = c.Element("FirstName").Value,
                                     LastName = c.Element("LastName").Value,
                                     ContactNo = int.Parse(c.Element("ContactNo").Value),
                                     Email = c.Element("Email").Value,
                                     Address = (from d in c.Descendants("Address")
                                                select new Address
                                                {
                                                    Country = d.Element("Country").Value,
                                                    City = d.Element("City").Value,
                                                    PostalCode = d.Element("PostalCode").Value
                                                }).FirstOrDefault()
                                 });

            LoadResource(employeeQuery);
        }

        private void LoadResource(IEnumerable<EmployeeXmlMapper> employeeQuery)
        {
            employeeQuery.ToList().ForEach(x =>
            {
                Resources.Add(new Employee
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ContactNo = x.ContactNo,
                    Email = x.Email,
                    Country = x.Address.Country,
                    City = x.Address.City,
                    PostalCode = x.Address.PostalCode
                });
            });
        }
    }
}
