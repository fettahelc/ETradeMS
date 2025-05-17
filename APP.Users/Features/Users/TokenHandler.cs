using APP.Users.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace APP.Users.Features.Users
{
    /// <summary>
    /// Handles token generation requests for user authentication.
    /// </summary>
    public class TokenHandler : UsersDbHandler, IRequestHandler<TokenRequest, TokenResponse>
    {
        private readonly AppSettings _appSettings;
        private readonly IConfiguration _configuration;
        
        public TokenHandler(UsersDb db, IConfiguration configuration, AppSettings appSettings) 
            : base(db)
        {
            _appSettings = appSettings;
            _configuration = configuration;
        }
        
        public async Task<TokenResponse> Handle(TokenRequest request, CancellationToken cancellationToken)
        {
            var user = await _db.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserName == request.UserName && 
                                        u.Password == request.Password && 
                                        u.IsActive, 
                                    cancellationToken);

            if (user == null)
            {
                return new TokenResponse(false, "Active user with the user name and password not found!");
            }

            var claims = GetClaims(user);
            var expiration = DateTime.UtcNow.AddMinutes(_appSettings.ExpirationInMinutes);
            var token = CreateAccessToken(claims, expiration);

            return new TokenResponse(true, "Token created successfully. Happy Birthday Cagıl Hocam \ud83c\udf82", token);
        }
    }
} 