using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private const string filePath = @"C:\Users\Ovi\Documents\the software guild\c sharp\bitbucket\ovi-simon-individual-work\SGBank.UI\Accounts.txt";

        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            var reader = File.ReadAllLines(filePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var account = new Account();

                account.AccountNumber = columns[0];
                account.Name = columns[1];
                account.Balance = decimal.Parse(columns[2]);
                if (columns[3] == "Free")
                    account.Type = AccountType.Free;
                if (columns[3] == "Basic")
                    account.Type = AccountType.Basic;
                if (columns[3] == "Premium")
                    account.Type = AccountType.Premium;

                accounts.Add(account);
            }

            return accounts;
        }

        public Account LoadAccount(string accountNumber)
        {
            List<Account> accounts = GetAccounts();
            return accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public void SaveAccount(Account accountToSave)
        {
            var accounts = GetAccounts();

            var currentAccount = accounts.First(a => a.AccountNumber == accountToSave.AccountNumber);
            currentAccount.Name = accountToSave.Name;
            currentAccount.Balance = accountToSave.Balance;
            currentAccount.Type = accountToSave.Type;

            OverwriteFile(accounts);
        }

        private void OverwriteFile(List<Account> accounts)
        {
            try
            {
                File.Delete(filePath);

                using (var writer = File.CreateText(filePath))
                {
                    writer.WriteLine("AccountNumber,Name,Balance,AccountType");

                    foreach (var account in accounts)
                    {
                        writer.WriteLine("{0},{1},{2},{3}", account.AccountNumber, account.Name, account.Balance, account.Type);
                    }
                }
            }

            catch
            {

            }
            
        }
    }
}
