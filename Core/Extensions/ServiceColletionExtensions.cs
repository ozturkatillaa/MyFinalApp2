using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public static class ServiceColletionExtensions
    {
        //extensionslar static olur
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            //neyi genişletmek istiyorsak this kullanıyoruz burada polimorfizm örneği yaptık
            foreach (var model in modules)
            {
                model.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
