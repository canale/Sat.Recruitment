using System;

namespace Sat.Recruitment.Domain.Dtos
{
    /// <summary>
    /// Represents an error.
    /// </summary>
    public class Error
    {
        private Type _targetType;

        /// <summary>
        /// Message Error.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Data Type of the resource which is managed within the request scope.
        /// </summary>
        public Type TargetType => _targetType ?? GetType();

        public Error(string message, Type targetType = null)
        {
            Message = message;
            _targetType = targetType;
        }
    }
}
