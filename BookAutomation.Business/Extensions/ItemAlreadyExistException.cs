using System;

namespace BookAutomation.Business.Exeptions
{
    public  class ItemAlreadyExistException:Exception
    {

        public ItemAlreadyExistException() { }

        public ItemAlreadyExistException(string message):base(message) {  }

        public ItemAlreadyExistException(string message, Exception inner):base(message, inner) {  } 
    }
}
