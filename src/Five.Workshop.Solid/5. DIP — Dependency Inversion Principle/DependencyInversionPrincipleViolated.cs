using Microsoft.Data.SqlClient;
using static System.String;

namespace Five.Workshop.Solid._5._DIP___Dependency_Inversion_Principle;

public class DependencyInversionPrincipleViolated
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Document { get; set; }
        public DateOnly CreatedAt { get; set; }

        public string? Validate()
        {
            if (IsNullOrEmpty(Email) || Email.Contains("@")) return "Invalid E-mail";
            if (IsNullOrEmpty(Document) || Document.Length != 11) return "Invalid Document";

            return null;
        }
    }

    public class CustomerRepository
    {
        public bool Save(Customer customer)
        {
            try
            {
                const string connectionString = "connection string value";
                using var connection = new SqlConnection(connectionString);
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    "INSERT INTO CUSTOMER (NAME, EMAIL DOCUMENT, CREATEDAT) VALUES (@name, @email, @doc, @created))";

                command.Parameters.AddWithValue("name", customer.Name);
                command.Parameters.AddWithValue("email", customer.Email);
                command.Parameters.AddWithValue("doc", customer.Document);
                command.Parameters.AddWithValue("created", customer.CreatedAt);
                command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class CustomerService
    {
        public string Add(Customer customer)
        {
            var error = customer.Validate();
            if (error is not null) return error;

            var repository = new CustomerRepository();

            var saved = repository.Save(customer);

            return !saved ? "Ops.. unexpected error" : "Customer created";
        }
    }
}