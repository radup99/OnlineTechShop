using OnlineTechShopApi.Repositories;
using OnlineTechShopApi.Models;
using OnlineTechShopApi.Enums;
using System.Security.Cryptography;
using OnlineTechShopApi.Entities;
using System.Text;

namespace OnlineTechShopApi.Services
{
    public class UserService(UserRepository uRep)
    {
        private readonly UserRepository _userRepository = uRep;

        public async Task<RegisterResult> RegisterUser(UserRegisterPostModel registerModel)
        {
            if (await _userRepository.ReadByUsername(registerModel.Username) != null)
                return RegisterResult.ExistingUsername;
            if (await _userRepository.ReadByEmailAddress(registerModel.EmailAddress) != null)
                return RegisterResult.ExistingEmail;

            User user = CreateUser(registerModel);
            await _userRepository.Create(user);
            return RegisterResult.Success;
        }

        private static User CreateUser(UserRegisterPostModel registerModel)
        {
            return new User
            {
                Username = registerModel.Username,
                PasswordHash = GenerateHash(registerModel.Password),
                Role = UserRole.Customer,
                EmailAddress = registerModel.EmailAddress,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                PhoneNumber = registerModel.PhoneNumber,
            };
        }

        private static string GenerateHash(string toHash)
        {
            var crypt = SHA256.Create();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(toHash));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            crypt.Dispose();
            return hash;
        }
    }
}
