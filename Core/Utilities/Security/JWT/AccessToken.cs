using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //kullanıcı mail dres ivs giriş yaptıktan sonra oluşturlan token ve süresi
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
