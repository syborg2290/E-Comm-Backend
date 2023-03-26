namespace backend.Services;

using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

public interface ICommonService
{

    string DecodeToken(string token);
    bool IsValid(string token);

}

public class CommonService : ICommonService
{
    public readonly IConfiguration configuration;

    public CommonService(
       IConfiguration Configuration
       )
    {
        configuration = Configuration;
    }

    public string DecodeToken(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var decodedValue = handler.ReadJwtToken(token);
            string userIdClaim = decodedValue.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            if (userIdClaim != null)
            {
                return userIdClaim;
            }

            return null;
        }
        catch (System.Exception)
        {

            return "";
        }
    }

    public bool IsValid(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:SecretKey"])),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        };

        try
        {
            SecurityToken validatedToken;
            tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            return true;
        }
        catch (SecurityTokenException)
        {
            // Token validation failed
            return false;
        }

    }

}