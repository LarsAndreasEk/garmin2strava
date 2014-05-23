using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        CloudTable GetAccountTable() 
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["Garmin2StravaTableStorage"]);
            var client = cloudStorageAccount.CreateCloudTableClient();
            var accountTable = client.GetTableReference("Account");
            accountTable.CreateIfNotExists();
            return accountTable;
        }

        public ActionResult Index()
        {
            var query =
                new TableQuery<Account>().Where(TableQuery.GenerateFilterCondition("PartitionKey",
                    QueryComparisons.Equal, "1"));

            var executeQuery = GetAccountTable().ExecuteQuery(query);


            return View(new Stuff(executeQuery));
        }

        [HttpPost]
        public ActionResult New(Guid id, string name)
        {
            GetAccountTable().Execute(TableOperation.Insert(new Account(id, name)));
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            var account = GetAccountTable().CreateQuery<Account>().Where(x => x.PartitionKey == "1" && x.RowKey == id.ToString());
            GetAccountTable().Execute(TableOperation.Delete(account.First()));
            return RedirectToAction("Index");
        }
    }
}