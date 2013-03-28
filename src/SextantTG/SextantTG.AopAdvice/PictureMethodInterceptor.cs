using AopAlliance.Intercept;
using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.AopAdvice
{
    public class PictureMethodInterceptor : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {
            if (invocation.Method.Name == "InsertPicture" || invocation.Method.Name == "UpdatePicture")
            {
                Assertion.AssertionApi.AssertForPicture(invocation.Arguments[0] as Picture);
            }
            return invocation.Proceed();
        }
    }
}
