using System;

namespace VirtualArtGallery.Entity
{
    public class Artwork
    {
        private int artworkId;
        private string title;
        private string description;
        private DateTime creationDate;
        private string medium;
        private string imageUrl;
        private int artistId;

        public Artwork() { }

        public Artwork(int artworkId, string title, string description, DateTime creationDate, string medium, string imageUrl, int artistId)
        {
            this.artworkId = artworkId;
            this.title = title;
            this.description = description;
            this.creationDate = creationDate;
            this.medium = medium;
            this.imageUrl = imageUrl;
            this.artistId = artistId;
        }

        public int ArtworkId { get => artworkId; set => artworkId = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public string Medium { get => medium; set => medium = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public int ArtistId { get => artistId; set => artistId = value; }
    }
}
