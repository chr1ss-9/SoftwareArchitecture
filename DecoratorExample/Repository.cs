using System.Data.SQLite;

namespace DecoratorExample {
    public class Repository : IRepository {
        private string connectionString;
        public Repository(string dbFilePath) {
            connectionString = $"Data Source={dbFilePath};Version=3;";
            CreateMyTable(); // Ensure the table exists when the repository is instantiated.
        }

        /// <summary>
        /// CREATE
        /// </summary>
        /// <param name="myData"></param>
        public void InsertData(Data myData) {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection)) {
                    command.CommandText = "INSERT INTO MyTable (Id, Name) VALUES (@id, @name)";
                    command.Parameters.AddWithValue("@id", myData.Id.ToString()); // Convert Guid to string
                    command.Parameters.AddWithValue("@name", myData.Name);
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// READ
        /// </summary>
        /// <returns></returns>
        public List<Data> GetAllData() {
            List<Data> data = new List<Data>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT Id, Name FROM MyTable", connection)) {
                    using (SQLiteDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            Guid id = ParseGuid(reader["Id"]);
                            string name = ParseString(reader["Name"]);
                            data.Add(new Data(id, name));
                        }
                    }
                }
            }

            return data;
        }
        /// <summary>
        /// UPDATE
        /// </summary>
        /// <param name="myData"></param>
        public void UpdateData(Data myData) {
            
            // Update database
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection)) {
                    command.CommandText = "UPDATE MyTable SET Name = @name WHERE Id = @id";
                    command.Parameters.AddWithValue("@name", myData.Name);
                    command.Parameters.AddWithValue("@id", myData.Id.ToString()); // Convert Guid to string
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteData(Guid id) {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection)) {
                    command.CommandText = "DELETE FROM MyTable WHERE Id = @id";
                    command.Parameters.AddWithValue("@id", id.ToString()); // Convert Guid to string
                    command.ExecuteNonQuery();
                }
            }
        }

        private void CreateMyTable() {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection)) {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS MyTable (Id TEXT PRIMARY KEY, Name TEXT)";
                    command.ExecuteNonQuery();
                }
            }
        }
        private Guid ParseGuid(object value) {
        #nullable disable
            if (value == DBNull.Value || value == null) {
                return Guid.Empty; // Return a default value when the value is null
            } else {
                return Guid.Parse(value.ToString());
            }
        }
        private string ParseString(object value) {
            if (value == DBNull.Value || value == null) {
                return string.Empty; // Return an empty string when the value is null
            } else {
                return value.ToString();
            }
        }
    }
}
