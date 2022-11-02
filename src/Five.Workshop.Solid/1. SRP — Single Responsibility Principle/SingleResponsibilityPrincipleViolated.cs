using Microsoft.Data.SqlClient;
using static System.String;

namespace Five.Workshop.Solid._1._SRP___Single_Responsibility_Principle;

public class SingleResponsibilityPrincipleViolated
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Document { get; set; }
        public DateOnly CreatedAt { get; set; }

        public string Add()
        {
            try
            {
                if (IsNullOrEmpty(Email) || Email.Contains("@")) return "Invalid E-mail";
                if (IsNullOrEmpty(Document) || Document.Length != 11) return "Invalid Document";

                const string connectionString = "connection string value";
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO CUSTOMER (NAME, EMAIL DOCUMENT, CREATEDAT) VALUES (@name, @email, @doc, @created))";

                command.Parameters.AddWithValue("name", Name);
                command.Parameters.AddWithValue("email", Email);
                command.Parameters.AddWithValue("doc", Document);
                command.Parameters.AddWithValue("created", CreatedAt);
                command.ExecuteNonQuery();

                return "Customer created";
            }
            catch
            {
                return "Ops.. unexpected error";
            }
        }
    }
}