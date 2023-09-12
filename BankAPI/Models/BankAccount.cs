using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankAPI.Models;


namespace BankAPI.Models
{
	public class BankAccount
	{

		public int Id { get; set; }
		public static int AccountSeed = 100;

		[Required]
		public string AccountNumber { get; } = null!;

		public decimal Balance { get; set; }

        public DateTime DateCreated { get; set; }

		[Required]
		public string Owner { get; set; } = null!;

		public ICollection<Transaction> Transactions { get; set; }

		public BankAccount()
		{
			AccountNumber = AccountSeed.ToString();
			AccountSeed++;
			Transactions = new List<Transaction>();

        }
	}
}

