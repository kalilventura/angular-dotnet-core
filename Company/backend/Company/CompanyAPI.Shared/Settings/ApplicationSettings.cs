namespace CompanyAPI.Shared.Settings
{
    public class ApplicationSettings
    {
        public int Expires { get; set; }
        public string JWT_Secret { get; set; }
        public string Client_URL { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}