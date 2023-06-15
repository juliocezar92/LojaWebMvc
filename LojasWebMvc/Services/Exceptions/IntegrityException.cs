using System;

namespace LojasWebMvc.Services.Exceptions
{
    public class IntegrityException : ApplicationException
    {
        
            public IntegrityException(string message): base(message)
            {
            }
        

    }
}
