using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankAPI.Data;
using BankAPI.Models;
using BankAPI.Services;



namespace BankAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {
        private readonly BankDBContext context;
        private readonly BankDataService bankDataService;

        public BankController(BankDBContext _context, BankDataService _bankDataService) {
            context = _context;
            bankDataService = _bankDataService;
        }


        [HttpGet]
        public ActionResult GetBankAccounts() {
            return Ok(bankDataService.GetBankAccounts());
        }


        [HttpGet("{Id}")]
        public ActionResult GetBankAccountById(int Id) {
            var bankAccount = bankDataService.GetBankAccountById(Id);
            if (bankAccount == null) {
                return NotFound();
            }
            return Ok(bankAccount);
        }


        [HttpPost]
        public ActionResult CreateAccount([FromBody] BankAccount bankAccount) {
            return Ok(bankDataService.CreateBankAccount(bankAccount));
        }


        [HttpDelete("{Id}")]
        public ActionResult DeleteAccount(int Id) {
            var bankAccount = bankDataService.DeleteBankAccountById(Id);

            if (bankAccount == null) {
                return NotFound();
            }

            return Ok($"Bank Account with  number {bankAccount.AccountNumber} has been removed");

        }

 
    }
}

