using System;

namespace VirtualArtGallery.Entity
{
    public class Gallery
    {
        private int galleryId;
        private string name;
        private string description;
        private string location;
        private int artistId;
        private string openingHours;

        public Gallery() { }

        public Gallery(int galleryId, string name, string description, string location, int artistId, string openingHours)
        {
            this.galleryId = galleryId;
            this.name = name;
            this.description = description;
            this.location = location;
            this.artistId = artistId;
            this.openingHours = openingHours;
        }

        public int GalleryId { get => galleryId; set => galleryId = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Location { get => location; set => location = value; }
        public int ArtistId { get => artistId; set => artistId = value; }
        public string OpeningHours { get => openingHours; set => openingHours = value; }
    }
}
