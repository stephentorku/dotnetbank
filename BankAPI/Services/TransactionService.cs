using System;
using BankAPI.Data;
using BankAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Services
{
	public class TransactionService
	{
		private readonly BankDBContext context;
		public TransactionService(BankDBContext _context)
		{
			context = _context;
		}

		public IEnumerable<Transaction>? GetTransactionsForAccountById(int Id) {
            var bankAccount = context.BankAccounts.Where(acc => acc.Id == Id).FirstOrDefault();
			if (bankAccount == null) {
				return Enumerable.Empty<Transaction>();
			}
			return bankAccount.Transactions;

        }

        public Transaction? MakeDeposit(int id, Transaction transaction)
        {
            var bankAccount = context.BankAccounts.Where(acc => acc.Id == id).FirstOrDefault();
            if (bankAccount == null)
            {
                return null;
            }
            transaction.BankAccountId = id;
            bankAccount.Balance += transaction.Amount;
            context.Transactions.Add(transaction);
            context.SaveChanges();
            return transaction;
        }

        public Transaction? MakeWithdrawal(int Id, Transaction transaction)
        {
            var bankAccount = context.BankAccounts.Where(acc => acc.Id == Id).FirstOrDefault();
            
            if (bankAccount == null)
            {
                return null;
            }
            transaction.Amount = -transaction.Amount;
            bankAccount.Balance += transaction.Amount;
            bankAccount.Transactions.Add(transaction);
            context.SaveChanges();
            return transaction;
        }
    }
}

