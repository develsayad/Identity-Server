using System.ComponentModel.DataAnnotations;

namespace Core.IdentitySvr.ViewModels
{
    public class RegisterViewModel
    {


        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(200)]
        [EmailAddress]
        public string EmailAddress { get; set; }


        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }


        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        public string? ReturnUrl { get; set; }




    }
}
