using System;

namespace SS.Domain.Errors
{
    public class UserCreatingException: Exception
    {
        public UserCreatingException(string msg, Exception ex)
            : base($"{msg} fail to bind model", ex)
        {
            
        }
    }
}
