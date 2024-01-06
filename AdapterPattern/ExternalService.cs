namespace AdapterPattern {
    public class ExternalService {
        private IExternalDataStore _externalDataStore;

        public ExternalService(IExternalDataStore externalDataStore) {
            _externalDataStore = externalDataStore;
        }

        public void ProcessExternalData() {
            // Fetch Data
            var externalData = _externalDataStore.FetchExternalData();
            Console.WriteLine("Processing external data:");
            foreach (var data in externalData) {
                // Process Data
                Console.WriteLine($"External Service Processing: {data.Name}");
            }
        }
    }
}
