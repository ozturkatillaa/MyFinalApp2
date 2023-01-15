using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SecurityKeyHelper
    {
        //ASP.NET VE JWT SERVSİLERİNİN ANLACAĞI ŞEKİLDE OLMASI LAZIM, APPSETTİNGS SECURİTY KEY ALANINA YARAR, bunu şifrelemek için, encrption key olarak byte haline gelmesi lazım, simetrik hale getiriyor
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
