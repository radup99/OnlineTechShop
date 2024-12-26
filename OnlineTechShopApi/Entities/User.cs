using OnlineTechShopApi.Enums;

namespace OnlineTechShopApi.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public UserRole Role { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public User() { }


    }
}
