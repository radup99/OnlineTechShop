using System.ComponentModel.DataAnnotations;
using OnlineTechShopApi.Enums;

namespace OnlineTechShopApi.Models
{
    public class UserRegisterPostModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public UserRegisterPostModel() { }
    }
}
