namespace Business.Models
{
    public class RefreshTokenSuccessModel
    {
        public RefreshTokenSuccessModel(string token, string refreshToken)
        {
            Token = token;
            RefreshToken = refreshToken;
        }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}