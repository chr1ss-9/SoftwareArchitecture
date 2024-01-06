namespace MediatorPattern {
    public class EmailNotifier {
        public EmailNotifier(IMediator mediator) {
            mediator.Subscribe("DataUpdated", (data) => {
                var updatedData = (Data)data;
                Console.WriteLine($"EMail Notifier \"work work\"Data updated: Name={updatedData.Name}");
            });
        }
    }
}