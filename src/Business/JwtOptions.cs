namespace Business
{
    public class JwtOptions
    {
        public const string Jwt = "Jwt";
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenLifeTimeInSeconds { get; set; }
        public string RefreshTokenLifeTimeInSeconds { get; set; }
    }
}
