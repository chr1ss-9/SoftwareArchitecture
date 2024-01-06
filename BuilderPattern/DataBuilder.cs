namespace BuilderPattern {
    public class DataBuilder {
        private Guid Id;
        private string Name = "default";
        public DataBuilder WithId(Guid id) {
            Id = id;
            return this;
        }
        public DataBuilder WithName(string name) {
            Name = name;
            return this;
        }
        public Data Build() {
            return new Data(Id, Name);
        }
    }
}
