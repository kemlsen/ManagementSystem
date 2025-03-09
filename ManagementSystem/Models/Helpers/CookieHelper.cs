namespace ManagementSystem.Models.Helpers
{
    public class CookieHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetCookie(string key, string value, int days = 7)
        {
            var options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(days),
                HttpOnly = true,
                Secure = true, 
                SameSite = SameSiteMode.Strict
            };

            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, options);
        }

        public string GetCookie(string key)
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(key, out var value);
            return value;
        }

        public void DeleteCookie(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

        public bool CookieExists(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies.ContainsKey(key);
        }
    }
}
