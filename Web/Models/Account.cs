using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Web.Models
{
    public class Account : TableEntity
    {
        public Account()
        {
            
        }
        public Account(Guid id, string name)
        {
            PartitionKey = "1";
            RowKey = id.ToString();
            Name = name;
        }

        public string Name { get; set; }
    }
}