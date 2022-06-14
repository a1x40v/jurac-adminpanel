namespace Application.DTO.Account
{
    public class AuthenticateResponse
    {
        public AccountDto Account { get; set; }
        public string JwtToken { get; set; }
    }
}