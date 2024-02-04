#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDS.Models
{
    public class UserLogin
    {
        [Required]
        [MinLength(2)]
        [Display(Name = "login ")]
        public string Login { get; set; }        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Mot de passe doit contenir au minimum 8 caractères!")]
        [Display(Name = "Password ")]
        public string Password { get; set; }

    }
}
