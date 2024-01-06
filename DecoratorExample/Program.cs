namespace DecoratorExample {
    internal class Program {
        static void Main(string[] args) {
            string dbFilePath = "your_database.db";
            var repository = new LoggingRepositoryDecorator(new Repository(dbFilePath));

            // Insert a new Data object
            Guid newId = Guid.NewGuid();
            var newData = new Data(newId, "Sample Data");
            repository.InsertData(newData);
            Console.WriteLine("MAIN: Inserted data.");

            // Retrieve all Data objects
            List<Data> allData = repository.GetAllData();
            Console.WriteLine("MAIN: All Data:");
            foreach (var data in allData) {
                Console.WriteLine($"MAIN: ID: {data.Id}, Name: {data.Name}");
            }

            // Update an existing Data object
            newData.ChangeName("Updated Data");
            repository.UpdateData(newData);
            Console.WriteLine("MAIN: Updated data.");
            # nullable disable
            // Retrieve the updated object
            var updatedData = repository.GetAllData().Find(d => d.Id == newId);
            Console.WriteLine($"MAIN: Updated Data - ID: {updatedData.Id}, Name: {updatedData.Name}");
            # nullable enable
            // Delete a Data object
            repository.DeleteData(newId);
            Console.WriteLine("MAIN: Deleted data.");

            // Check if the data was deleted
            var deletedData = repository.GetAllData().Find(d => d.Id == newId);
            if (deletedData == null) {
                Console.WriteLine("MAIN: Data with ID not found. It has been deleted.");
            } else {
                Console.WriteLine("MAIN: Data with ID still exists. Deletion failed.");
            }
        }
    }
}