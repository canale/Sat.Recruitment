using System;

namespace Sat.Recruitment.Domain.Guards
{
    public abstract class Guard
    {
        public static ObjectGuard For(object target) => new ObjectGuard(target);
        public static StringGuard For(string target) => new StringGuard(target);

        protected void Eval(Func<bool> predicate, Exception exception)
        {
            if (predicate())
            {
                throw exception;
            }
        }
    }
}
