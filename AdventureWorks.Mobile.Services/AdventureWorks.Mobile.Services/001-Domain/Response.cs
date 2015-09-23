


namespace AdventureWorks.Mobile.Services._001_Domain
{
    public class BaseResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string SessionKey { get; set; }
        public string ErrorCode { get; set; }
    }
}