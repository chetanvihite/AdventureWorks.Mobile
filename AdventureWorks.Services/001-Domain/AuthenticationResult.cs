

namespace AdventureWorks.Services._001_Domain
{
    public class AuthenticationResult
    {
        public bool IsSuccess { get; set; }

        public string SessionKey { get; set; }

        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }

        public UserProfile Profile { get; set; }
    }
}
