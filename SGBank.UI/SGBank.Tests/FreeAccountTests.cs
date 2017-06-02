using NUnit.Framework;
using SGBank.BLL;
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
    class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }

        [TestCase ("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase ("12345", "Free Account", 100, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]
        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance, 
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit depo = new FreeAccountDepositRule();
            Account newAccount = new Account();

            newAccount.AccountNumber = accountNumber;
            newAccount.Name = name;
            newAccount.Balance = balance;
            newAccount.Type = accountType;

            AccountDepositResponse response = depo.Deposit(newAccount, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -150, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, true)]
        public void FreeAccountWithdrawTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new FreeAccountWithdrawRule();
            Account newAccount = new Account();

            newAccount.AccountNumber = accountNumber;
            newAccount.Name = name;
            newAccount.Balance = balance;
            newAccount.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(newAccount, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }
}
