using CORE.APP.Features;

namespace APP.Users.Features.Users
{
    public class TokenResponse : CommandResponse
    {
        public string Token { get; set; }

        public TokenResponse(bool isSuccessful, string message = "", string token = "") : base(isSuccessful, message)
        {
            Token = token;
        }
    }
} 