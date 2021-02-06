using System;
using System.Collections.Generic;
using System.Web.Http;
using refactor_this.Models;
using refactor_this.Services;

namespace refactor_this.Controllers
{
    public class AccountController : ApiController
    {
        private AccountQueryService accountQueryService { get; set; }

        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetById(Guid id)
        {
            return Ok(accountQueryService.Get(id));
        }

        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult Get()
        {
            var accounts = new List<Account>();
           
            foreach (var id in accountQueryService.GetAccountIds())
            {
                var account = accountQueryService.Get(id);
                accounts.Add(account);
            }
            return Ok(accounts);
        }

        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            accountQueryService.Save(account);
            return Ok();
        }

        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult Update(Guid id, Account account)
        {
            var existing = accountQueryService.Get(id);
            if (existing != null)
            {
                existing.Name = account.Name;
                accountQueryService.Save(existing);
            }
            return Ok();
        }

        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            var existing = accountQueryService.Get(id);
            // check if we get an account then delete
            if (existing != null)
                accountQueryService.DeleteById(id);
            return Ok();
        }

        
    }
}