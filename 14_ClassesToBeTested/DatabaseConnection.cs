using System.Data.SqlClient;

namespace _14_ClassesToBeTested;

public class DatabaseConnection : IDatabaseConnection
{
    private const string ConnectionString =
        "Data Source=MainServer;Initial Catalog=People;User ID=Admin;Password=12345;";

    public Person GetById(int id)
    {
        Person person = null;

        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            string query = "SELECT * FROM Persons WHERE ID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", id);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                int personID = (int)reader["Id"];
                string firstName = reader["Name"].ToString();
                string lastName = reader["LastName"].ToString();

                person = new Person(personID, firstName, lastName);
            }

            reader.Close();
        }

        return person;
    }

    public void Write(int id, Person person)
    {
        throw new NotImplementedException();
    }
}
