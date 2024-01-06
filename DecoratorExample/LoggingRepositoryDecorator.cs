namespace DecoratorExample {
    public class LoggingRepositoryDecorator : IRepository {
        private readonly IRepository _repository;
        public LoggingRepositoryDecorator(IRepository repository) {
            _repository = repository;
        }
        public void InsertData(Data myData) {
            Console.WriteLine("LOGGING: Adding data: " + myData.Name);
            _repository.InsertData(myData);
        }
        public List<Data> GetAllData() {
            Console.WriteLine("LOGGING: Getting all data");
            return _repository.GetAllData();
        }
        public void UpdateData(Data myData) {
            Console.WriteLine("LOGGING: Updating data: " + myData.Name);
            _repository.UpdateData(myData);
        }
        public void DeleteData(Guid id) {
            Console.WriteLine("LOGGING: Deleting data by ID: " + id);
            _repository.DeleteData(id);
        }
    }
}
