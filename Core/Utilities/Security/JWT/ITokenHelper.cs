using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //kullancıı login olduktan sonra login bilsgiler iile vertabanına gider token oluşturur geri client a gönderir
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
