using System.ComponentModel.DataAnnotations.Schema;

namespace mcfFrontEnd.Models
{
    public class UserLogin
    {
        public string? UserName { get; set; }

        public string? Password { get; set; }

    }
}
