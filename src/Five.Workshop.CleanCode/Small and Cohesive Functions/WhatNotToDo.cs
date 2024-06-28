public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // Validate order
        if (order == null) throw new ArgumentNullException(nameof(order));
        if (order.Items.Count == 0) throw new ArgumentException("Order has no items");

        // Save order to database
        using (var connection = new SqlConnection("connectionString"))
        {
            connection.Open();
            var command = new SqlCommand("INSERT INTO Orders...", connection);
            command.ExecuteNonQuery();
        }

        // Send confirmation email
        var smtpClient = new SmtpClient();
        smtpClient.Send(new MailMessage("sales@company.com", order.CustomerEmail)
        {
            Subject = "Order Confirmation",
            Body = "Thank you for your order!"
        });
    }
}
