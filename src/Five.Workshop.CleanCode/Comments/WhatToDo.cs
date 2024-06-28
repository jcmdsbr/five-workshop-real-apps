public class CustomerService
{
    public void AddCustomer(Customer customer)
    {
        // Save the customer to the database
        SaveCustomerToDatabase(customer);
    }

    private void SaveCustomerToDatabase(Customer customer)
    {
        // Logic to save customer to the database
    }
}
