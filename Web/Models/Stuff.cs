namespace Web.Models
{
    public class Stuff
    {
        public string ConnectionString { get; set; }

        public Stuff(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}