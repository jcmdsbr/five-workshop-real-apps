// See https://aka.ms/new-console-template for more information


public class Customer
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public record CountCustomer(int Count);


public static class Helper
{
    public static IEnumerable<Customer> FilterWhereNameIsNotNull(this IEnumerable<Customer> customers)
    {
        return customers.Where(customer => customer.Name is not null);
    }

    public static IEnumerable<Customer> GetCustomersStartsWithLetterA(this IEnumerable<Customer> customers)
    {
        return customers.Where(customer => customer.Name!.StartsWith('a'));
    }
}


public class Main
{
    public void Execute()
    {
        // instancia valor
        var customers = new List<Customer>();
        //pega valor que começa com a letra As
        var customersStartsWithLetterA = customers.FilterWhereNameIsNotNull().GetCustomersStartsWithLetterA();
        var countCustomersStartsWithLetterAAndIdEven = customersStartsWithLetterA.Count(GetValuesByRN255);
        var countCustomer = new CountCustomer(countCustomersStartsWithLetterAAndIdEven);
    }

    /// <summary>
    ///  Aplica a RN 255 ref ao impost XYZ
    /// </summary>
    private static bool GetValuesByRN255(Customer x) => ((x.Id*200)/10)%2==0;

   
}



