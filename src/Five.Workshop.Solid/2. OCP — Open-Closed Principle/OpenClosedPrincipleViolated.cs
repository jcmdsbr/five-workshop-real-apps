namespace Five.Workshop.Solid._2._OCP___Open_Closed_Principle;

public class OpenClosedPrincipleViolated
{
    public class DebitAccount
    {
        public enum TypeAccount
        {
            Checking,
            Savings
        }

        public void Execute(decimal amount, string account, TypeAccount typeAccount)
        {
            switch (typeAccount)
            {
                case TypeAccount.Checking:
                    // Debit checking account
                    break;
                case TypeAccount.Savings:
                    // Debit savings
                    break;
            }
        }
    }
}