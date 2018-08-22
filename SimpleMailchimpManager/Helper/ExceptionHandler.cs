using System;

namespace SimpleMailchimpManager.Helper
{
    internal static class ExceptionHandler
    {
        internal static void HandleNullArgument<T>(T parameter, string errorMessage)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter), errorMessage);
        }

        internal static void HandleEmptyStringArgument(string parameter, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(parameter)) throw new ArgumentException(errorMessage);
        }
    }
}