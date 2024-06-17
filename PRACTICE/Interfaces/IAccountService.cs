using PRACTICE.Models;

namespace PRACTICE.Interfaces
{
    public interface IAccountService
    {
        public string CreateJwtToken(AppUser user);
    }
}
