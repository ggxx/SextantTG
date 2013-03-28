using AopAlliance.Intercept;
using SextantTG.ActiveRecord;
using SextantTG.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.AopAdvice
{
    public class SightsMethodInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            if (invocation.Method.Name == "InsertSights" || invocation.Method.Name == "UpdateSightsFromOld")
            {
                Assertion.AssertionApi.AssertForSights(invocation.Arguments[0] as Sights);
            }
            return invocation.Proceed();
        }
    }
}
