using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //aop yapısını yugulyacak yapı autıfac üzerinden geliyor, core katmanı için autıface paketklerini ekledik
    //intercepter araya girmek demeke, bu yapı sayesinde sürekli try cache yazmaya gerek klalmaz veya sürekkli log log gerek kalmaz
    //fieldların, propertylerin üzerinden attirute olarak loglama vs ekleyeceğiz bu yapı bu yüzden lazım 
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}
