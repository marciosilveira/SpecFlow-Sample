using System.Collections.Generic;

namespace SpecFlowSample
{
    public class Bank
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }

        public Bank(string name, List<Account> accounts)
        {
            Name = name;
            Accounts = accounts;
        }
    }
}
