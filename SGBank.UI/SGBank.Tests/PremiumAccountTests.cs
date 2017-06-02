using NUnit.Framework;
using SGBank.BLL.WithdrawRules;
using SGBank.Data.DepositRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    class PremiumAccountTests
    {
        [TestCase("44444", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 250, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit depo = new NoLimitDepositRule();
            Account newAccount = new Account();

            newAccount.AccountNumber = accountNumber;
            newAccount.Name = name;
            newAccount.Balance = balance;
            newAccount.Type = accountType;

            AccountDepositResponse response = depo.Deposit(newAccount, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("44444", "Premium Account", 1500, AccountType.Premium, -1000, 500, true)]
        [TestCase("44444", "Premium Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("44444", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        [TestCase("44444", "Premium Account", 100, AccountType.Premium, -150, -60, true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
            Account newAccount = new Account();

            newAccount.AccountNumber = accountNumber;
            newAccount.Name = name;
            newAccount.Balance = balance;
            newAccount.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(newAccount, amount);

            Assert.AreEqual(expectedResult, response.Success);
            if (response.Success == true)
            {
                Assert.AreEqual(newBalance, response.Account.Balance);
            }
        }
    }
}
