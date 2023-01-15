using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //SECURED OPRETAİONS A BAGLI, ıoc YAPISI OLUŞTRUDUK,  DEPENDENCY INJECTION YAPMAMIZ ICIN GEREKLIYDI
        //apı DE VAR İOS YAPISI AMA WİNDOWS FROM MASAÜSTÜ PROGRAMŞLARINDA KULLANMAK İSTERSEM BU DA LAZIM
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
