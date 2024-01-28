using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApp.Models.Db
{
    public class Request
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}
