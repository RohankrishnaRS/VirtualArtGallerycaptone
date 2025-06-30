using NUnit.Framework;
using VirtualArtGallery.Entity;
using VirtualArtGallery.DAO;

namespace VirtualArtGallery.Tests
{
    [TestFixture]
    public class GalleryTests
    {
        private GalleryServiceImpl _galleryService;

        [SetUp]
        public void Setup()
        {
            _galleryService = new GalleryServiceImpl();
        }

        [Test]
        public void AddGallery_ShouldReturnTrue_WhenValidGallery()
        {
            var gallery = new Gallery
            {
                Name = "Test Gallery",
                Description = "Test Description",
                Location = "Test Location",
                ArtistId = 1,
                OpeningHours = "9 AM - 5 PM"
            };

            var result = _galleryService.AddGallery(gallery);
            Assert.IsTrue(result, "Adding valid gallery should succeed.");
        }

        [Test]
        public void UpdateGallery_ShouldReturnTrue_WhenGalleryExists()
        {
            var gallery = new Gallery
            {
                GalleryId = 1, // Use existing GalleryId
                Name = "Updated Gallery",
                Description = "Updated Description",
                Location = "Updated Location",
                ArtistId = 1,
                OpeningHours = "10 AM - 6 PM"
            };

            var result = _galleryService.UpdateGallery(gallery);
            Assert.IsTrue(result, "Updating existing gallery should succeed.");
        }

        [Test]
        public void RemoveGallery_ShouldReturnTrue_WhenGalleryExists()
        {
            var result = _galleryService.RemoveGallery(1); // Use existing GalleryId
            Assert.IsTrue(result, "Removing existing gallery should succeed.");
        }

        [Test]
        public void SearchGalleries_ShouldReturnNonEmpty_WhenKeywordMatches()
        {
            var results = _galleryService.SearchGalleries("Test");
            Assert.IsNotNull(results, "Search should not return null.");
            Assert.IsNotEmpty(results, "Search should return results.");
        }
    }
}
