using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CateringManagementPlatform.BLL.Auth
{
    public class AuthOptions
    {
        public string Issuer { get; set; } // издатель токена
        public string Audience { get; set; } // потребитель токена
        public string Secret { get; set; }   // ключ для шифрации
        public int TokenLifetime { get; set; } // время жизни токена 

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}
