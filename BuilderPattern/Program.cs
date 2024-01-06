namespace BuilderPattern {
    internal class Program {
        static void Main(string[] args) {
            Data data1 = new DataBuilder().WithName("New Data 1").WithId(Guid.NewGuid()).Build();
            Data data2 = new DataBuilder().WithName("New Data 2").Build();
            Data data3 = new DataBuilder().Build();
            Console.WriteLine("done");
        }
    }
}