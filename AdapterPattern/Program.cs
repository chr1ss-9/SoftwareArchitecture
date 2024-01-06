namespace AdapterPattern {
    internal class Program {
        static void Main(string[] args) {
            string dbFilePath = "adapter_example_database";
            // ------------- SETUP --------------
            // Create an instance of the Repository adapter
            IRepository dataRepository = new Repository(dbFilePath);

            dataRepository.InsertData(new Data(Guid.NewGuid(), "Example Data 1" + DateTime.Now.ToString("HHmmss:fff tt")));
            dataRepository.InsertData(new Data(Guid.NewGuid(), "Example Data 2" + DateTime.Now.ToString("HHmmss:fff tt")));
            dataRepository.InsertData(new Data(Guid.NewGuid(), "Example Data 3" + DateTime.Now.ToString("HHmmss:fff tt")));

            // ------------ PATTERN -------------
            // Create an instance of the ExternalService adapter
            IExternalDataStore externalDataSourece = new ExternalServiceAdapter(dbFilePath);

            // Create an instance of the ExternalService
            var externalService = new ExternalService(externalDataSourece);

            // Process external data using the ExternalService
            externalService.ProcessExternalData();
        }
    }
}
