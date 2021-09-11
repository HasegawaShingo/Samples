using System;

namespace SampleCustomException
{
    public class HogeHogeException : Exception
    {
        public HogeHogeException() { }

        public HogeHogeException(string message) : base(message) { }

        public HogeHogeException(string message, Exception inner):base(message, inner) { }
    }
}
