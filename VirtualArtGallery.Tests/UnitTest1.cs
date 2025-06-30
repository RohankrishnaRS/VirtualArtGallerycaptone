using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using VirtualArtGallery.DAO;
using VirtualArtGallery.Entity;

namespace VirtualArtGallery.Tests
{
    [TestClass]
    public class VirtualArtGalleryTests
    {
        private IVirtualArtGallery _artGalleryService;
        private IGalleryService _galleryService;

        [TestInitialize]
        public void Setup()
        {
            _artGalleryService = new VirtualArtGalleryImpl();
            _galleryService = new GalleryServiceImpl();
        }

        // ---------------------- Artwork Management Tests ----------------------

        [TestMethod]
        public void AddArtwork_ShouldReturnTrue_WhenArtworkIsAdded()
        {
            Artwork artwork = new Artwork
            {
                Title = "Test Artwork Insert",
                Description = "Test Description Insert",
                CreationDate = DateTime.Now,
                Medium = "Oil",
                ImageUrl = "http://test.com/art.jpg",
                ArtistId = 1 // Ensure Artist ID 1 exists
            };

            bool result = _artGalleryService.AddArtwork(artwork);
            Assert.IsTrue(result, "Artwork was not added successfully.");
        }

        [TestMethod]
        public void UpdateArtwork_ShouldReturnTrue_WhenArtworkIsUpdated()
        {
            // Add artwork first
            Artwork artwork = new Artwork
            {
                Title = "Artwork To Update",
                Description = "Test Description",
                CreationDate = DateTime.Now,
                Medium = "Oil",
                ImageUrl = "http://test.com/update.jpg",
                ArtistId = 1
            };

            bool addResult = _artGalleryService.AddArtwork(artwork);
            Assert.IsTrue(addResult, "Failed to add artwork for update.");

            List<Artwork> artworks = _artGalleryService.SearchArtworks("Artwork To Update");
            Assert.IsTrue(artworks.Count > 0, "Artwork not found for update.");

            int artworkId = artworks[0].ArtworkId;

            // Now update
            Artwork updatedArtwork = new Artwork
            {
                ArtworkId = artworkId,
                Title = "Updated Artwork",
                Description = "Updated Description",
                CreationDate = DateTime.Now,
                Medium = "Acrylic",
                ImageUrl = "http://test.com/updated.jpg",
                ArtistId = 1
            };

            bool updateResult = _artGalleryService.UpdateArtwork(updatedArtwork);
            Assert.IsTrue(updateResult, "Artwork update failed.");
        }

        [TestMethod]
        public void RemoveArtwork_ShouldReturnTrue_WhenArtworkIsDeleted()
        {
            // Add artwork to delete
            Artwork artwork = new Artwork
            {
                Title = "Artwork To Delete",
                Description = "Will be deleted",
                CreationDate = DateTime.Now,
                Medium = "Watercolor",
                ImageUrl = "http://test.com/delete.jpg",
                ArtistId = 1
            };

            bool addResult = _artGalleryService.AddArtwork(artwork);
            Assert.IsTrue(addResult, "Failed to add artwork for deletion.");

            List<Artwork> artworks = _artGalleryService.SearchArtworks("Artwork To Delete");
            Assert.IsTrue(artworks.Count > 0, "Artwork not found for deletion.");

            int artworkId = artworks[0].ArtworkId;

            bool deleteResult = _artGalleryService.RemoveArtwork(artworkId);
            Assert.IsTrue(deleteResult, "Artwork deletion failed.");

            // Verify deletion
            List<Artwork> deletedArtworks = _artGalleryService.SearchArtworks("Artwork To Delete");
            Assert.IsTrue(deletedArtworks.Count == 0, "Artwork was not deleted properly.");
        }

        [TestMethod]
        public void SearchArtworks_ShouldReturnResults_WhenKeywordMatches()
        {
            // Add artwork for this specific search
            Artwork artwork = new Artwork
            {
                Title = "Unique Search Artwork",
                Description = "For search testing",
                CreationDate = DateTime.Now,
                Medium = "Oil",
                ImageUrl = "http://test.com/search.jpg",
                ArtistId = 1
            };

            bool addResult = _artGalleryService.AddArtwork(artwork);
            Assert.IsTrue(addResult, "Failed to add artwork for search testing.");

            List<Artwork> artworks = _artGalleryService.SearchArtworks("Unique Search Artwork");
            Assert.IsTrue(artworks.Count > 0, "No artworks found matching the keyword.");
        }

        // ---------------------- Gallery Management Tests ----------------------

        [TestMethod]
        public void AddGallery_ShouldReturnTrue_WhenGalleryIsAdded()
        {
            Gallery gallery = new Gallery
            {
                Name = "Test Gallery Insert",
                Description = "Test Gallery Description Insert",
                Location = "Test Location",
                ArtistId = 1,
                OpeningHours = "10 AM - 5 PM"
            };

            bool result = _galleryService.AddGallery(gallery);
            Assert.IsTrue(result, "Gallery was not added successfully.");
        }

        [TestMethod]
        public void UpdateGallery_ShouldReturnTrue_WhenGalleryIsUpdated()
        {
            // Add gallery first
            Gallery gallery = new Gallery
            {
                Name = "Gallery To Update",
                Description = "Test Description",
                Location = "Test Location",
                ArtistId = 1,
                OpeningHours = "10 AM - 5 PM"
            };

            bool addResult = _galleryService.AddGallery(gallery);
            Assert.IsTrue(addResult, "Failed to add gallery for update.");

            List<Gallery> galleries = _galleryService.SearchGalleries("Gallery To Update");
            Assert.IsTrue(galleries.Count > 0, "Gallery not found for update.");

            int galleryId = galleries[0].GalleryId;

            // Now update
            Gallery updatedGallery = new Gallery
            {
                GalleryId = galleryId,
                Name = "Updated Gallery",
                Description = "Updated Description",
                Location = "Updated Location",
                ArtistId = 1,
                OpeningHours = "9 AM - 6 PM"
            };

            bool updateResult = _galleryService.UpdateGallery(updatedGallery);
            Assert.IsTrue(updateResult, "Gallery update failed.");
        }

        [TestMethod]
        public void RemoveGallery_ShouldReturnTrue_WhenGalleryIsDeleted()
        {
            // Add gallery to delete
            Gallery gallery = new Gallery
            {
                Name = "Gallery To Delete",
                Description = "Will be deleted",
                Location = "Test Location",
                ArtistId = 1,
                OpeningHours = "11 AM - 7 PM"
            };

            bool addResult = _galleryService.AddGallery(gallery);
            Assert.IsTrue(addResult, "Failed to add gallery for deletion.");

            List<Gallery> galleries = _galleryService.SearchGalleries("Gallery To Delete");
            Assert.IsTrue(galleries.Count > 0, "Gallery not found for deletion.");

            int galleryId = galleries[0].GalleryId;

            bool deleteResult = _galleryService.RemoveGallery(galleryId);
            Assert.IsTrue(deleteResult, "Gallery deletion failed.");

            // Verify deletion
            List<Gallery> deletedGalleries = _galleryService.SearchGalleries("Gallery To Delete");
            Assert.IsTrue(deletedGalleries.Count == 0, "Gallery was not deleted properly.");
        }

        [TestMethod]
        public void SearchGalleries_ShouldReturnResults_WhenKeywordMatches()
        {
            // Add gallery for this specific search
            Gallery gallery = new Gallery
            {
                Name = "Unique Search Gallery",
                Description = "For search testing",
                Location = "Search Location",
                ArtistId = 1,
                OpeningHours = "9 AM - 5 PM"
            };

            bool addResult = _galleryService.AddGallery(gallery);
            Assert.IsTrue(addResult, "Failed to add gallery for search testing.");

            List<Gallery> galleries = _galleryService.SearchGalleries("Unique Search Gallery");
            Assert.IsTrue(galleries.Count > 0, "No galleries found matching the keyword.");
        }
    }
}
