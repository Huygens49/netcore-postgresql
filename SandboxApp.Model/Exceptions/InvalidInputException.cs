using System;

namespace SandboxApp.Model.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }
}
