using static System.String;

namespace Five.Workshop.Solid._5._DIP___Dependency_Inversion_Principle;

internal class DependencyInversionPrinciple
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

    public interface ICustomerRepository
    {
        bool Save(Customer customer);
    }

    public interface ICustomerService
    {
        string Add(Customer customer);
    }

    public class CustomerRepository : ICustomerRepository
    {
        public bool Save(Customer customer)
        {
            // impl
            return true;
        }
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public string Add(Customer customer)
        {
            var error = customer.Validate();
            if (error is not null) return error;

            var saved = _customerRepository.Save(customer);

            return !saved ? "Ops.. unexpected error" : "Customer created";
        }
    }
}