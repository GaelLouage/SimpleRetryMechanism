namespace SimpleRetryMechanism.Helpers
{
    public class RetryHelper
    {
        public static async Task<T?> ExecuteWithRetry<T>(Func<Task<T>> operation, int maxRetries, TimeSpan delay)
        {
            for (int i = 0; i < maxRetries; i++) 
            {
                try
                {
                    return await operation?.Invoke();
                }
                catch 
                {
                    await Task.Delay(delay);
                }
                if(i == maxRetries -1)
                {
                    throw new Exception("Failed all retries!");
                }
            }
            return default(T?);
        }
    }
}
