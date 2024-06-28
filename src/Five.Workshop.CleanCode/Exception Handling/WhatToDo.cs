public class OrderService
{
    public void ProcessOrder(Order order)
    {
        try
        {
            // Process order
        }
        catch (Exception ex)
        {
            // Log the exception
            Console.WriteLine("Error processing order: " + ex.Message);
            throw new OrderProcessingException("An error occurred while processing the order", ex);
        }
    }
}

public class OrderProcessingException : Exception
{
    public OrderProcessingException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
