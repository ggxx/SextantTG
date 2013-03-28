using AopAlliance.Intercept;
using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.AopAdvice
{
    public class SubTourMethodInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            //Assertion.AssertionApi.AssertForSubTour(invocation.Arguments[0] as SubTour);
            return invocation.Proceed();
        }
    }
}
