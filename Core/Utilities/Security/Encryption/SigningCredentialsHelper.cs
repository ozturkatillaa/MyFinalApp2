using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        //veriyi şifrelerken hangi algoritmayı kullanacaksın hangi şifreleme yöntemi kullanılacak burada belirlenir, yani anahtar nasıl olacak
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey , SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
