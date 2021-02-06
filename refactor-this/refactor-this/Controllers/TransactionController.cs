using System;
using System.Web.Http;
using refactor_this.Models;
using refactor_this.Services;

namespace refactor_this.Controllers
{
    public class TransactionController : ApiController
    {
        private TransactionQueryService transactionQueryService { get; set; }

        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult GetTransactions(Guid id)
        {
            return Ok(transactionQueryService.GetTransactions(id));
        }

        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transaction transaction)
        {
            var transactionResponse = transactionQueryService.AddTransaction(id, transaction);

            switch (transactionResponse)
            {
                case TransactionQueryService.TransactionResponse.Ok:
                    return Ok();
                case TransactionQueryService.TransactionResponse.UpdateError:
                    return BadRequest("Could not update account amount");
                case TransactionQueryService.TransactionResponse.InsertError:
                    return BadRequest("Could not insert the transaction");
                default:
                    return Ok();
            }
        }
    }
}