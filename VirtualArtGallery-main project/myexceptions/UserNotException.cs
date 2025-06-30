using System;

namespace VirtualArtGallery.MyExceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base() { }

        public UserNotFoundException(string message) : base(message) { }
    }
}
