namespace AdapterPattern {
    public interface IRepository {
        void DeleteData(Guid id);
        List<Data> GetAllData();
        void InsertData(Data myData);
        void UpdateData(Data myData);
    }
}