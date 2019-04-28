namespace DesignPatterns.Library.StructuralPatterns.Adapter.Readers
{
    public class Employee : IModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ContactNo { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
    }
}
