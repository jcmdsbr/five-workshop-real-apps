namespace Five.Workshop.Solid._4._ISP___Interface_Segregation_Principle;

public class InterfaceSegregationPrinciple
{
    public interface IRegisterService
    {
        void Save();
    }

    public interface IMailService
    {
        void Send();
    }

    public class CustomerService : IRegisterService
    {
        public void Save()
        {
            // save
        }
    }

    public class MailService : IMailService
    {
        public void Send()
        {
            // send e-mail
        }
    }
}