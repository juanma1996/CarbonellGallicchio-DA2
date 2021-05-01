using System.ComponentModel.DataAnnotations;

namespace Model.In
{
    public class SessionModel
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
