namespace DesignPatterns.Library.StructuralPatterns.Adapter.Readers
{
    public class IrisModel : IModel
    {
        public double SepalLength { get; set; }
        public double SepalWidth { get; set; }
        public double PetalLength { get; set; }
        public double PetalWidth { get; set; }
        public string Class { get; set; }
    }
}
