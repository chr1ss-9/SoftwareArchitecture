namespace MediatorPattern {
    class Program {
        static void Main(string[] args) {
            // Create the mediator
            IMediator mediator = new Mediator();

            // Create components that subscribe to events
            var dataLogger = new DataLogger(mediator);
            var emailNotifier = new EmailNotifier(mediator);

            // Simulate events
            var data1 = new Data (Guid.NewGuid(), "Data 1" );
            mediator.Publish("DataInserted", data1);
            var data2 = new Data (Guid.NewGuid(), "Data 2" );
            mediator.Publish("DataInserted", data2);
            data2.Name = "Data 2 Updated";
            mediator.Publish("DataUpdated", data2);

            Console.ReadKey();
        }
    }
}