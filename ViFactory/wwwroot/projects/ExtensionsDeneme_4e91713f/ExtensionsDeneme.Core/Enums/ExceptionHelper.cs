namespace ExtensionsDeneme.Core.Helpers
{
    public static class ExceptionHelper
    {
        public static List<Exception> GetInnerExceptions(this Exception ex, List<Exception>? exceptions = null)
        {
            exceptions = exceptions ?? new List<Exception>();

            if (ex == null)
                return exceptions;

            exceptions.Add(ex);

            if (ex.InnerException != null)
                return GetInnerExceptions(ex.InnerException, exceptions);
            else
                return exceptions;
        }

        public static List<string> GetInnerExceptionMessages(this Exception ex, List<string>? messages = null)
        {
            messages = messages ?? new List<string>();

            if (ex == null)
                return messages;

            messages.Add(ex.Message);

            if (ex.InnerException != null)
                return GetInnerExceptionMessages(ex.InnerException, messages);
            else
                return messages;
        }
    }
}


