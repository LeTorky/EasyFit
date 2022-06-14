using System.ComponentModel.DataAnnotations;

namespace CoachingApp.DTO
{
    public class UserConfirmToken
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string OldEmail { get; set; }
    }
}
