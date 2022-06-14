using System.ComponentModel.DataAnnotations;

namespace CoachingApp.DTO
{
    public class UserChangePassDTO
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }
}
