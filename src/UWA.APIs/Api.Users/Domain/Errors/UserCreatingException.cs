using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors
{
    public class UserCreatingException: Exception
    {
        public UserCreatingException(string msg, Exception ex)
            : base($"{msg} fail to bind model", ex)
        {
            
        }
    }
}
