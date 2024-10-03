namespace just_bid_it_api.Auth
{
    public interface IAuthenticationManager
    {
        string GenerateToken(string username);
    }
}