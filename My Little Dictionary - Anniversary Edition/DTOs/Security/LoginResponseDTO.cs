namespace My_Little_Dictionary___Anniversary_Edition.DTOs.Security
{
    public class LoginResponseDTO
    {
        public enum LoginStatus { Success, Failure }
        public string Token { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public LoginStatus LoginStatusCode { get; set; }
        public string Status => LoginStatusCode.ToString();

        public LoginResponseDTO(string token,  DateTime expiration, Guid refreshToken)
        {
            Token = token;
            Expiration = expiration;
            LoginStatusCode = LoginStatus.Success;
            RefreshToken = refreshToken;
        }
    }
}
