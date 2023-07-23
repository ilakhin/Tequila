using System;
using System.Diagnostics.CodeAnalysis;

namespace Tequila.Utilities
{
    public static class ExceptionUtility
    {
        [DoesNotReturn]
        public static void ThrowInvalidOperationException()
        {
            throw new InvalidOperationException();
        }

        [DoesNotReturn]
        public static void ThrowArgumentException(string paramName)
        {
            throw new ArgumentException(paramName);
        }

        public static void ThrowArgumentException_IfNullOrWhiteSpace(string instance, string paramName)
        {
            if (string.IsNullOrWhiteSpace(instance))
            {
                ThrowArgumentException(paramName);
            }
        }

        [DoesNotReturn]
        public static void ThrowArgumentOutOfRangeException(string paramName, object actualValue, string message)
        {
            throw new ArgumentOutOfRangeException(paramName, actualValue, message);
        }

        [DoesNotReturn]
        public static void ThrowArgumentNullException(string paramName)
        {
            throw new ArgumentNullException(paramName);
        }

        public static void ThrowArgumentNullException_IfNull(object instance, string paramName)
        {
            if (instance == null)
            {
                ThrowArgumentNullException(paramName);
            }
        }

        [DoesNotReturn]
        public static void ThrowOperationCanceledException()
        {
            throw new OperationCanceledException();
        }

        [DoesNotReturn]
        public static void ThrowOperationCanceledException(string message)
        {
            throw new OperationCanceledException(message);
        }
    }
}
