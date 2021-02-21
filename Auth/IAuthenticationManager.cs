namespace just_bid_it_api.Auth
{
    public interface IAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}