using System;
using Microsoft.EntityFrameworkCore;
using BankAPI.Models;

namespace BankAPI.Data
{
	public class BankDBContext : DbContext
	{
        protected readonly IConfiguration Configuration;

		public DbSet<BankAccount> BankAccounts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        


        public BankDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}

