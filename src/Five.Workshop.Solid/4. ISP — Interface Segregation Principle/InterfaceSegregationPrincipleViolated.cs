namespace Five.Workshop.Solid._4._ISP___Interface_Segregation_Principle;

public class InterfaceSegregationPrincipleViolated
{
    public interface IService
    {
        void Save();
        void Send();
    }

    public class RegisterCustomerService : IService
    {
        public void Save()
        {
            // save
        }

        public void Send()
        {
            // Not Implemented
        }
    }

    public class MailService : IService
    {
        public void Save()
        {
            // Not Implemented
        }

        public void Send()
        {
            // send welcome e-mail
        }
    }
}