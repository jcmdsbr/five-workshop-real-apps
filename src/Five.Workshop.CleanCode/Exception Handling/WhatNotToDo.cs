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
            // Log the exception and swallow it
            Console.WriteLine("Error processing order: " + ex.Message);
        }
    }
}
