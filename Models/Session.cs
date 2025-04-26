namespace PNET_semestralka_blazor_app.Models
{
    public class Session
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Session(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? UserEmail
        {
            get => _httpContextAccessor.HttpContext?.Session.GetString("UserEmail");
            set => _httpContextAccessor.HttpContext?.Session.SetString("UserEmail", value ?? "");
        }

        public string? Role
        {
            get => _httpContextAccessor.HttpContext?.Session.GetString("UserRole");
            set => _httpContextAccessor.HttpContext?.Session.SetString("UserRole", value ?? "");
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext?.Session.Remove("UserEmail");
            _httpContextAccessor.HttpContext?.Session.Remove("UserRole");
        }

        public bool IsLoggedIn => !string.IsNullOrEmpty(UserEmail);
    }

}
