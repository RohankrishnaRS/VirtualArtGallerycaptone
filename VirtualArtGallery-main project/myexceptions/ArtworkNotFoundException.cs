using System;

namespace VirtualArtGallery.MyExceptions
{
    public class ArtworkNotFoundException : Exception
    {
        public ArtworkNotFoundException() : base() { }

        public ArtworkNotFoundException(string message) : base(message) { }
    }
}
