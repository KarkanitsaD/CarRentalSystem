namespace Business.Models.Authenticate
{
    public class RefreshTokenResponseModel
    {
        public RefreshTokenResponseModel(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}