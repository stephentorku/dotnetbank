using System;
namespace BankAPI.Models
{
	public class Transaction
	{
		public int Id { get; set; }

		public string Description { get; set; } = null!;

		public decimal Amount { get; set; }

		public DateTime TransactionDate { get; set; }

		public int BankAccountId { get; set; }

		public Transaction()
		{
		}
	}
}

