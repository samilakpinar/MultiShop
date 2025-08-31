namespace MultiShop.Basket.LoginService
{
    public class LoginService : ILoginService
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext?.User?.FindFirst("sub")?.Value ?? string.Empty;
    }
}
