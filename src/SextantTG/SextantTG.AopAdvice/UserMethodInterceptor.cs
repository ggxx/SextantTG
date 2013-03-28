using AopAlliance.Intercept;
using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.AopAdvice
{
    public class UserMethodInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            if (invocation.Method.Name == "InsertUser")
            {
                Assertion.AssertionApi.AssertForUser(invocation.Arguments[1].ToString());
            }
            return invocation.Proceed();
        }
    }
}
