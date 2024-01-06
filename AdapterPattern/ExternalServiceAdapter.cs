namespace AdapterPattern {
    class ExternalServiceAdapter : IExternalDataStore {
        private Repository _repository;

        public ExternalServiceAdapter(string dbFilePath) {
            _repository = new Repository(dbFilePath);
        }

        public List<Data> FetchExternalData() {
            // Here, we adapt the Repository to work with the IExternalDataSource interface
            var repositoryData = _repository.GetAllData();
            return repositoryData.Select(d => new Data(d.Id, d.Name)).ToList();
        }
    }
}
