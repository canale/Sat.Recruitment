using System;

namespace Sat.Recruitment.Domain.Guards
{
    public class DecimalGuard : Guard
    {
        private readonly decimal _target;

        internal DecimalGuard(decimal target)
        {
            _target = target;
        }


        public DecimalGuard IsNegative(string message = "The argument should be equal or grater than cero.")
        {
            Eval(() => _target < 0, new ArgumentException(message));
            return this;
        }

    }
}
