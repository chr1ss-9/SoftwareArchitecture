namespace MediatorPattern {
    public class DataLogger {
        public DataLogger(IMediator mediator) {
            mediator.Subscribe("DataInserted", (data) => {
                var insertedData = (Data)data;
                Console.WriteLine($"DataLogger \"work work\" inserted: ID={insertedData.Id}, Name={insertedData.Name}");
            });
        }
    }
}