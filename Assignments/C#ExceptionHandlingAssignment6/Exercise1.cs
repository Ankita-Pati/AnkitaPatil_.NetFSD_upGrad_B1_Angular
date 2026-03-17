namespace C_ExpectionHandlingAssignment6
{
    class CheckBalanceException : Exception
    {
        public CheckBalanceException(string message) : base(message)
        {
        }
    }
    class BankAccount
    {
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public static double Balance = 0;

        public BankAccount(int accNo, string name, double balance)
        {
            AccountNumber = accNo;
            Name = name;
            Balance = balance;
        }

        public void Transaction(char type, double amount)
        {
            if (type == 'd') // deposit
            {
                Balance += amount;
                Console.WriteLine("Deposited: " + amount);
            }
            else if (type == 'c') // withdrawal
            {
                if (Balance - amount < 500)
                {
                    throw new CheckBalanceException("Minimum balance of 500 should be maintained!");
                }
                Balance -= amount;
                Console.WriteLine("Withdrawn: " + amount);
            }

            Console.WriteLine("Current Balance: " + Balance);
        }
    }
    internal class Exercise1
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount acc = new BankAccount(101, "Rahul", 1000);

                acc.Transaction('d', 500);   // deposit
                acc.Transaction('c', 1200);  // withdrawal (may throw exception)
            }
            catch (CheckBalanceException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
