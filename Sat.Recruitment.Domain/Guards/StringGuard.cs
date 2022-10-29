using System;
using System.Text.RegularExpressions;

namespace Sat.Recruitment.Domain.Guards
{
    public class StringGuard : Guard
    {
        private readonly string _target;

        internal StringGuard(string target)
        {
            _target = target;
        }


        public StringGuard IsNullOrEmpty(string message = "The argument shouldn't be null")
        {
            Eval(() => string.IsNullOrEmpty(_target), new ArgumentNullException(message));
            return this;
        }

        public StringGuard IsNotNull(string message = "The argument should be null")
        {
            Eval(() => !string.IsNullOrEmpty(_target), new ArgumentException(message));
            return this;
        }

        public StringGuard IsLonger(int length, string message = "The argument is too long", Exception? exception = null)
        {
            Eval(() => _target.Length > length, exception ?? new ArgumentException(message));
            return this;
        }

        public StringGuard IsShorter(int length, string message = "The argument is too short", Exception? exception = null)
        {
            Eval(() => _target.Length < length, exception ?? new ArgumentException(message));
            return this;
        }

        public StringGuard Match(Regex exp, string message = "The argument shouldn't match", Exception? exception = null)
        {
            Eval(() => exp.Match(_target).Success, exception ?? new ArgumentException(message));
            return this;
        }

        public StringGuard NotMatch(Regex exp, string message = "The argument should match", Exception? exception = null)
        {
            Eval(() => !exp.Match(_target).Success, exception ?? new ArgumentException(message));
            return this;
        }
    }
}
