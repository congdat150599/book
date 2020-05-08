using System.ComponentModel.DataAnnotations;

namespace frame.Models
{
    public class User
    {
        public int idUser { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [MinLength(4,ErrorMessage = "Password tối thiểu 4 kí tự")]
        public string password { get; set; }
        public string role { get; set; }
    }
}