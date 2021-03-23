using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ConsoleCoreSandbox2021
{
    [Table("People")]
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public bool IsMarried { get; set; }
    }
}
