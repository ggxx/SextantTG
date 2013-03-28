using AopAlliance.Intercept;
using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.AopAdvice
{
    public class TourMethodInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            if (invocation.Method.Name == "InsertTour" || invocation.Method.Name == "UpdateTourFromOld")
            {
                Assertion.AssertionApi.AssertForTour(invocation.Arguments[0] as Tour);
            }
            return invocation.Proceed();
        }
    }
}
