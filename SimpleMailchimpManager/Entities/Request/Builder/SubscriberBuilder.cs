using SimpleMailchimpManager.Helper;

namespace SimpleMailchimpManager.Entities.Request.Builder
{
    internal static class SubscriberBuilder
    {
        internal static Subscriber Build(string email, string status)
        {
            ExceptionHandler.HandleEmptyStringArgument(email, "Email cannot be null.");
            ExceptionHandler.HandleEmptyStringArgument(status, "Status cannot be null.");

            return new Subscriber(email, status);
        }

        internal static Subscriber Build(
            string email,
            string status,
            MergeVar mergeVar)
        {
            ExceptionHandler.HandleEmptyStringArgument(email, "Email cannot be null.");
            ExceptionHandler.HandleEmptyStringArgument(status, "Status cannot be null.");
            ExceptionHandler.HandleNullArgument(mergeVar, "MergeVar cannot be null.");

            return new Subscriber(email, status, mergeVar);
        }
    }
}