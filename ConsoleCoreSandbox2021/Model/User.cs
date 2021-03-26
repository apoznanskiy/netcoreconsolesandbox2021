using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleCoreSandbox2021.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
