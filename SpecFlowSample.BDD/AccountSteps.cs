using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecFlowSample.BDD
{
    [Binding]
    public class TestarAsOperacoesBasicasDeContaSteps
    {
        private Account _account;

        [Given(@"a conta criada para o dono ""(.*)"" de numero (.*) com o limite (.*) e saldo (.*)")]
        public void DadoAContaCriadaParaODonoDeNumeroComOLimiteESaldo(string holder, int accountNumber, int limit, int balance)
        {
            _account = new Account(holder, accountNumber, balance, limit);
        }

        [When(@"o dono realiza o deposito no valor de (.*) na conta")]
        public void QuandoODonoRealizaODepositoNoValorDeNaConta(double depositAmount)
        {
            Assert.IsTrue(_account.Deposit(depositAmount),
                $"O dono { _account.Holder } não tem limite disponível na conta para este valor de depósito.");
        }

        [When(@"o dono realiza o primeiro saque no valor de (.*) na conta")]
        public void QuandoODonoRealizaOPrimeiroSaqueNoValorDeNaConta(double value)
        {
            Assert.IsTrue(_account.Withdraw(value),
                $"O dono { _account.Holder } não tem saldo disponível na conta para este valor de saque");
        }

        [When(@"o dono realiza o segundo saque no valor de (.*) na conta")]
        public void QuandoODonoRealizaOSegundoSaqueNoValorDeNaConta(double value)
        {
            Assert.IsTrue(_account.Withdraw(value),
                $"O dono { _account.Holder } não tem saldo disponível na conta para este valor de saque");
        }

        [Then(@"o dono tem o saldo no valor de (.*) na conta")]
        public void EntaoODonoTemOSaldoNoValorDeNaConta(double totalBalance)
        {
            Assert.AreEqual(totalBalance, _account.Balance,
                $"O dono { _account.Holder } está com o saldo incorreto na conta.");
        }
    }
}
