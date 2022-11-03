using System;

namespace Sat.Recruitment.Domain.Guards
{
    public class ObjectGuard : Guard
    {
        private readonly object _target;

        internal ObjectGuard(object target)
        {
            _target = target;
        }

        public ObjectGuard IsNull(string message = "The argument shouldn't be null")
        {
            Eval(() => _target is null, new ArgumentNullException(message));
            return this;
        }

        public ObjectGuard IsNotNull(string message = "The argument should be null")
        {
            Eval(() => !(_target is null), new ArgumentException(message));
            return this;
        }
    }
}
