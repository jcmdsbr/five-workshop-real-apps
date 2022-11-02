namespace Five.Workshop.Solid._2._OCP___Open_Closed_Principle;

public class OpenClosedPrinciple
{
    public abstract class DebitAccount
    {
        public abstract void Execute(decimal amount, string account);
    }

    public class DebitCheckingAccount : DebitAccount
    {
        public override void Execute(decimal amount, string account)
        {
            // Debit checking account
        }
    }

    public class DebitSavingsAccount : DebitAccount
    {
        public override void Execute(decimal amount, string account)
        {
            // Debit savings
        }
    }
}