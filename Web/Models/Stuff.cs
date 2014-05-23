using System;
using System.Collections.Generic;
using Web.Controllers;

namespace Web.Models
{
    public class Stuff
    {
        public IEnumerable<Account> Accounts { get; set; }
        public Guid NewId { get; set; }

        public Stuff(IEnumerable<Account> accounts)
        {
            Accounts = accounts;
            NewId = Guid.NewGuid();
        }
    }
}