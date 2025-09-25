using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
