#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDS.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(2)]
        [Display(Name = "login ")]
        public string Login { get; set; }        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        [Display(Name = "Password ")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [NotMapped]
        [Compare("Password",ErrorMessage ="Passwords Do Not Match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your Password")]
        public string PwConfirm { get; set; }
    }
}
