namespace DecoratorExample {
    public class Data {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        #nullable disable
        public Data(Guid id, string name) {
            Id = id;
            ChangeName(name);
        }
        public void ChangeName(string name = "") {
            Name = name;
        }
    }
}
