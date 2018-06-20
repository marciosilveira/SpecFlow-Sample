using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SpecFlowSample.BDD
{
    [Binding]
    public class BankSteps
    {
        private Bank _bank;
        private int _totalAccount;
        private double _totalCashBank;

        [Given(@"que as contas sao do ""(.*)""")]
        public void DadoQueAsContasSaoDo(string bankName, Table table)
        {
            _bank = new Bank(bankName, new List<Account>());
        }

        [Given(@"o calculo do total de contas criadas")]
        public void DadoOCalculoDoTotalDeContasCriadas()
        {
            _totalAccount = _bank.Accounts.Count;
        }

        [Given(@"o calculo do total de dinheiro")]
        public void DadoOCalculoDoTotalDeDinheiro()
        {
            _totalCashBank = _bank.Accounts.Sum(o => o.Balance);
        }

        [Then(@"o total de contas e (.*)")]
        public void EntaoOTotalDeContasE(int totalAccount)
        {
            Assert.AreEqual(totalAccount, _totalAccount, "O cálculo do total de contas está incorreto");
        }

        [Then(@"o total de dinheiro no banco e (.*)")]
        public void EntaoOTotalDeDinheiroNoBancoE(int totalCashBank)
        {
            Assert.AreEqual(totalCashBank, _totalCashBank,
                $"O cálculo do total de dinheiro no banco { _bank.Name } está incorreto");
        }
    }
}
