using System;

namespace BookAutomation.Business.Exeptions
{
    public class ItemNotValidException : Exception
    {
        public ItemNotValidException() { }

        public ItemNotValidException(string message) : base(message) { }

        public ItemNotValidException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
