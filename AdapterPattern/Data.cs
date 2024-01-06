namespace AdapterPattern {
    public class Data {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Data(Guid id, string name) {
            Id = id;
            Name = name;
        }
    }

}
