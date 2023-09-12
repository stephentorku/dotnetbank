using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAPI.Data;
using BankAPI.Models;
using BankAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    public class TransactionController : Controller
    {

        private readonly BankDBContext context;
        private readonly TransactionService transactionService;

        public TransactionController(BankDBContext _context, TransactionService _transactionService) {
            context = _context;
            transactionService = _transactionService;
        }

        [HttpGet("{Id}")]
        public ActionResult GetAllTransactionsForAccount(int Id)
        {
            return Ok(transactionService.GetTransactionsForAccountById(Id));
        }

        [HttpPost("deposit/{Id}")]
        public ActionResult MakeDeposit(int Id, [FromBody] Transaction transaction)
        {
            var trans = transactionService.MakeDeposit(Id, transaction);
            if (trans == null)
            {
                return Ok();
            }
            
            return Ok($"Deposit made for account no:{Id} with amount {transaction.Amount}");
        }

        [HttpPost("withdraw/{Id}")]
        public ActionResult MakeWithdrawal(int Id, [FromBody] Transaction transaction)
        {
            var trans = transactionService.MakeDeposit(Id, transaction);
            if (trans == null)
            {
                return NotFound();
            }

            return Ok($"Withdrawal made for account no:{Id} with amount {transaction.Amount}");
        }

    }
}

