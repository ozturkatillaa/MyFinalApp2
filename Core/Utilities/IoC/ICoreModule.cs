using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        
        //bunun amacı dependency reselvers olan alanları core altında tüm projelerde kullanmak için bu oluşturuldu.
        void Load(IServiceCollection serviceCollection);
    }
}
