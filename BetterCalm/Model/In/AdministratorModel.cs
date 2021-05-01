using System;
using System.ComponentModel.DataAnnotations;

namespace Model.In
{
    public class AdministratorModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
