using System;
using BankAPI.Data;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Services
{
	public class BankDataService
	{

        private readonly BankDBContext context;

        public BankDataService(BankDBContext _context)
        {
            context = _context;
        }

        public IEnumerable<BankAccount> GetBankAccounts() {
            return context.BankAccounts;
        }

        public BankAccount? GetBankAccountById(int id) {
            var bankAccount = context.BankAccounts.Where(acc => acc.Id == id).FirstOrDefault();
            if (bankAccount == null)
            {
                return null;
            }
            return bankAccount;
        }

        public string CreateBankAccount(BankAccount bankAccount) {
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            return ($"Account created for {bankAccount.Owner}");
        }

        public BankAccount? DeleteBankAccountById(int id) {
            var bankAccount = context.BankAccounts.Find(id);

            if (bankAccount == null)
            {
                return null;
            }
            context.BankAccounts.Remove(bankAccount);
            context.SaveChanges();
            return bankAccount;
        }
	}
}

