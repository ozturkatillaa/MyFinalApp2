using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace Business.BusinessAspects.Autofac
{
    // JWT icin
    //yetki işlemleri procdut manager da mesela add operasyonu için attribute olarak kullanndık
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //_PRODUCTDAL = PRODUCT SERVİCE AUTO FAC ALANINDAKİ GİBİ İNJECTİON YAPMAYA YARAR
        }


        //yetkleri gez bak [SecuredOperation("product.add,admin")] 
        //protected override void OnBefore(IInvocation invocation)
        //{
        //    var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
        //    foreach (var role in _roles)
        //    {
        //        if (roleClaims.Contains(role))
        //        {
        //            return;
        //        }
        //    }
        //    throw new Exception(Messages.AuthorizationDenied);
        //}

        protected override void OnBefore(IInvocation invocation)
        {
            //var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //foreach (var role in _roles)
            //{
            //    if (roleClaims.Contains(role))
            //    {
            //        return;
            //    }
            //}
            var token = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (token != "")
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var decodeToken = jwtSecurityToken.Claims;
                foreach (var claim in decodeToken)
                {
                    foreach (var role in _roles)
                    {
                        if (claim.ToString().Contains(role))
                        {
                            return;
                        }
                    }
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
