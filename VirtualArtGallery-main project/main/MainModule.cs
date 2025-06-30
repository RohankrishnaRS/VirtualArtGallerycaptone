using System;
using System.Collections.Generic;
using VirtualArtGallery.DAO;
using VirtualArtGallery.Entity;
using VirtualArtGallery.MyExceptions;

namespace VirtualArtGallery.Main
{
    public class MainModule
    {
        private readonly IVirtualArtGallery galleryService = new VirtualArtGalleryImpl();
        private readonly IGalleryService galleryManager = new GalleryServiceImpl();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== Virtual Art Gallery ===");
                Console.WriteLine("1. Add Artwork");
                Console.WriteLine("2. Update Artwork");
                Console.WriteLine("3. Remove Artwork");
                Console.WriteLine("4. Get Artwork by ID");
                Console.WriteLine("5. Search Artworks");
                Console.WriteLine("6. Add Artwork to Favorites");
                Console.WriteLine("7. Remove Artwork from Favorites");
                Console.WriteLine("8. View User Favorite Artworks");
                Console.WriteLine("9. Add Gallery");
                Console.WriteLine("10. Update Gallery");
                Console.WriteLine("11. Remove Gallery");
                Console.WriteLine("12. Get Gallery by ID");
                Console.WriteLine("13. Search Galleries");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddArtwork();
                            break;
                        case 2:
                            UpdateArtwork();
                            break;
                        case 3:
                            RemoveArtwork();
                            break;
                        case 4:
                            GetArtworkById();
                            break;
                        case 5:
                            SearchArtworks();
                            break;
                        case 6:
                            AddToFavorites();
                            break;
                        case 7:
                            RemoveFromFavorites();
                            break;
                        case 8:
                            GetUserFavorites();
                            break;
                        case 9:
                            AddGallery();
                            break;
                        case 10:
                            UpdateGallery();
                            break;
                        case 11:
                            RemoveGallery();
                            break;
                        case 12:
                            GetGalleryById();
                            break;
                        case 13:
                            SearchGalleries();
                            break;
                        case 0:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (ArtworkNotFoundException ex)
                {
                    Console.WriteLine($"Artwork Error: {ex.Message}");
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine($"User Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void AddArtwork()
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Creation Date (yyyy-mm-dd): ");
            DateTime creationDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Medium: ");
            string medium = Console.ReadLine();
            Console.Write("Enter Image URL: ");
            string imageUrl = Console.ReadLine();
            Console.Write("Enter Artist ID: ");
            int artistId = int.Parse(Console.ReadLine());

            Artwork artwork = new Artwork(0, title, description, creationDate, medium, imageUrl, artistId);
            bool success = galleryService.AddArtwork(artwork);
            Console.WriteLine(success ? "Artwork added successfully." : "Failed to add artwork.");
        }

        private void UpdateArtwork()
        {
            Console.Write("Enter Artwork ID to update: ");
            int artworkId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Title: ");
            string title = Console.ReadLine();
            Console.Write("Enter New Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter New Creation Date (yyyy-mm-dd): ");
            DateTime creationDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter New Medium: ");
            string medium = Console.ReadLine();
            Console.Write("Enter New Image URL: ");
            string imageUrl = Console.ReadLine();
            Console.Write("Enter New Artist ID: ");
            int artistId = int.Parse(Console.ReadLine());

            Artwork artwork = new Artwork(artworkId, title, description, creationDate, medium, imageUrl, artistId);
            bool success = galleryService.UpdateArtwork(artwork);
            Console.WriteLine(success ? "Artwork updated successfully." : "Failed to update artwork.");
        }

        private void RemoveArtwork()
        {
            Console.Write("Enter Artwork ID to remove: ");
            int artworkId = int.Parse(Console.ReadLine());

            bool success = galleryService.RemoveArtwork(artworkId);
            Console.WriteLine(success ? "Artwork removed successfully." : "Failed to remove artwork.");
        }

        private void GetArtworkById()
        {
            Console.Write("Enter Artwork ID: ");
            int artworkId = int.Parse(Console.ReadLine());

            Artwork artwork = galleryService.GetArtworkById(artworkId);
            Console.WriteLine($"Title: {artwork.Title}, Description: {artwork.Description}, Medium: {artwork.Medium}");
        }

        private void SearchArtworks()
        {
            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine();

            List<Artwork> artworks = galleryService.SearchArtworks(keyword);
            foreach (var art in artworks)
            {
                Console.WriteLine($"ID: {art.ArtworkId}, Title: {art.Title}");
            }
        }

        private void AddToFavorites()
        {
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Enter Artwork ID: ");
            int artworkId = int.Parse(Console.ReadLine());

            bool success = galleryService.AddArtworkToFavorite(userId, artworkId);
            Console.WriteLine(success ? "Added to favorites." : "Failed to add to favorites.");
        }

        private void RemoveFromFavorites()
        {
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());
            Console.Write("Enter Artwork ID: ");
            int artworkId = int.Parse(Console.ReadLine());

            bool success = galleryService.RemoveArtworkFromFavorite(userId, artworkId);
            Console.WriteLine(success ? "Removed from favorites." : "Failed to remove from favorites.");
        }

        private void GetUserFavorites()
        {
            Console.Write("Enter User ID: ");
            int userId = int.Parse(Console.ReadLine());

            List<Artwork> favorites = galleryService.GetUserFavoriteArtworks(userId);
            foreach (var art in favorites)
            {
                Console.WriteLine($"ID: {art.ArtworkId}, Title: {art.Title}");
            }
        }

        private void AddGallery()
        {
            Console.Write("Enter Gallery Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Location: ");
            string location = Console.ReadLine();
            Console.Write("Enter Artist ID: ");
            int artistId = int.Parse(Console.ReadLine());
            Console.Write("Enter Opening Hours: ");
            string openingHours = Console.ReadLine();

            Gallery gallery = new Gallery(0, name, description, location, artistId, openingHours);
            bool success = galleryManager.AddGallery(gallery);
            Console.WriteLine(success ? "Gallery added successfully." : "Failed to add gallery.");
        }

        private void UpdateGallery()
        {
            Console.Write("Enter Gallery ID to update: ");
            int galleryId = int.Parse(Console.ReadLine());

            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter New Description: ");
            string description = Console.ReadLine();
            Console.Write("Enter New Location: ");
            string location = Console.ReadLine();
            Console.Write("Enter New Artist ID: ");
            int artistId = int.Parse(Console.ReadLine());
            Console.Write("Enter New Opening Hours: ");
            string openingHours = Console.ReadLine();

            Gallery gallery = new Gallery(galleryId, name, description, location, artistId, openingHours);
            bool success = galleryManager.UpdateGallery(gallery);
            Console.WriteLine(success ? "Gallery updated successfully." : "Failed to update gallery.");
        }

        private void RemoveGallery()
        {
            Console.Write("Enter Gallery ID to remove: ");
            int galleryId = int.Parse(Console.ReadLine());

            bool success = galleryManager.RemoveGallery(galleryId);
            Console.WriteLine(success ? "Gallery removed successfully." : "Failed to remove gallery.");
        }

        private void GetGalleryById()
        {
            Console.Write("Enter Gallery ID: ");
            int galleryId = int.Parse(Console.ReadLine());

            Gallery gallery = galleryManager.GetGalleryById(galleryId);
            if (gallery != null)
                Console.WriteLine($"Name: {gallery.Name}, Description: {gallery.Description}, Location: {gallery.Location}");
            else
                Console.WriteLine("Gallery not found.");
        }

        private void SearchGalleries()
        {
            Console.Write("Enter keyword to search galleries: ");
            string keyword = Console.ReadLine();

            List<Gallery> galleries = galleryManager.SearchGalleries(keyword);
            foreach (var gal in galleries)
            {
                Console.WriteLine($"ID: {gal.GalleryId}, Name: {gal.Name}");
            }
        }
    }
}
