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

        public bool IsLoggedIn => !string.IsNullOrEmpty(UserEmail);
    }

}
