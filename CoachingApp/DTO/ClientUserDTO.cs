using CoachingApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CoachingApp.DTO
{
    public class ClientUserDTO:Client
    {
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string PassWord { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}
