namespace SpecFlowSample
{
    public class Account
    {
        public string Holder { get; private set; }
        public int Number { get; private set; }
        public double Balance { get; private set; }
        public double Limit { get; private set; }

        public Account(string holder, int number, double balance, double limit)
        {
            Holder = holder;
            Number = number;
            Balance = balance;
            Limit = limit;
        }

        private bool CanWithdraw(double value) => value <= Balance;
        private bool CanDeposit(double value) => value + Balance <= Limit;

        public bool Withdraw(double value)
        {
            if (!CanWithdraw(value))
                return false;

            Balance -= value;
            return true;
        }

        public bool Deposit(double value)
        {
            if (!CanDeposit(value))
                return false;

            Balance += value;
            return true;
        }
    }
}
