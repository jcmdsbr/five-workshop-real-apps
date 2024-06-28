public class OrderValidator
{
    public void Validate(Order order)
    {
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (order.Items.Count == 0) throw new ArgumentException("Order has no items");
    }
}

public class OrderRepository
{
    public void Save(Order order)
    {
        using (var connection = new SqlConnection("connectionString"))
        {
            connection.Open();
            var command = new SqlCommand("INSERT INTO Orders...", connection);
            command.ExecuteNonQuery();
        }
    }
}

public class EmailService
{
    public void SendOrderConfirmation(string customerEmail)
    {
        var smtpClient = new SmtpClient();
        smtpClient.Send(new MailMessage("sales@company.com", customerEmail)
        {
            Subject = "Order Confirmation",
            Body = "Thank you for your order!"
        });
    }
}

public class OrderProcessor
{
    private readonly OrderValidator _validator = new OrderValidator();
    private readonly OrderRepository _repository = new OrderRepository();
    private readonly EmailService _emailService = new EmailService();

    public void ProcessOrder(Order order)
    {
        _validator.Validate(order);
        _repository.Save(order);
        _emailService.SendOrderConfirmation(order.CustomerEmail);
    }
}
